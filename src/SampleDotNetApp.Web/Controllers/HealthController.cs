using Microsoft.AspNetCore.Mvc;
using SampleDotNetApp.Web.Services;

namespace SampleDotNetApp.Web.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    private readonly IHealthService _healthService;
    private readonly ILogger<HealthController> _logger;

    public HealthController(IHealthService healthService, ILogger<HealthController> logger)
    {
        _healthService = healthService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetHealth(CancellationToken cancellationToken)
    {
        var payload = await _healthService.GetHealthAsync(cancellationToken);
        _logger.LogInformation("Health probe returned {Status} at {Timestamp} for {Environment}",
            payload.Status, payload.Timestamp, payload.Environment);
        return Ok(payload);
    }
}
