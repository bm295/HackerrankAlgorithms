using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using SampleDotNetApp.Web.Services;

namespace SampleDotNetApp.Tests;

public class HealthEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public HealthEndpointTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetHealth_ReturnsHealthyPayload()
    {
        var response = await _client.GetAsync("/health");

        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<HealthPayload>();

        Assert.NotNull(payload);
        Assert.Equal("Healthy", payload?.Status);
        Assert.False(string.IsNullOrWhiteSpace(payload?.Version));
        Assert.NotNull(payload?.Timestamp);
    }
}
