using System.Diagnostics;
using System.Reflection;

namespace SampleDotNetApp.Web.Services;

public interface IHealthService
{
    Task<HealthPayload> GetHealthAsync(CancellationToken cancellationToken = default);
}

public sealed record HealthPayload(
    string Status,
    DateTime Timestamp,
    string Environment,
    string Version,
    string Message);

public sealed class HealthService : IHealthService
{
    private readonly IConfiguration _configuration;
    private readonly IHostEnvironment _environment;
    private readonly string _version;

    public HealthService(IHostEnvironment environment, IConfiguration configuration)
    {
        _environment = environment;
        _configuration = configuration;
        _version = ResolveVersion();
    }

    public Task<HealthPayload> GetHealthAsync(CancellationToken cancellationToken = default)
    {
        var welcomeMessage = _configuration.GetValue<string>("Health:WelcomeMessage") ?? "Service is healthy";
        return Task.FromResult(new HealthPayload(
            Status: "Healthy",
            Timestamp: DateTime.UtcNow,
            Environment: _environment.EnvironmentName,
            Version: _version,
            Message: welcomeMessage));
    }

    private static string ResolveVersion()
    {
        var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
        var version =
            FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion ??
            assembly.GetName().Version?.ToString() ??
            "0.0.0";

        return version;
    }
}
