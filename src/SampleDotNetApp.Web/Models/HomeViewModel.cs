using SampleDotNetApp.Web.Services;

namespace SampleDotNetApp.Web.Models;

public sealed class HomeViewModel
{
    public string Environment { get; init; } = string.Empty;
    public string Version { get; init; } = string.Empty;
    public DateTime ServerTime { get; init; }
    public HealthPayload? Health { get; init; }
    public string HealthSummary { get; init; } = string.Empty;
}
