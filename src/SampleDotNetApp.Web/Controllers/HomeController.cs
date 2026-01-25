using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SampleDotNetApp.Web.Models;
using SampleDotNetApp.Web.Services;

namespace SampleDotNetApp.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHealthService _healthService;

    public HomeController(ILogger<HomeController> logger, IHealthService healthService)
    {
        _logger = logger;
        _healthService = healthService;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var health = await _healthService.GetHealthAsync(cancellationToken);
        var model = new HomeViewModel
        {
            Environment = health.Environment,
            Version = health.Version,
            ServerTime = DateTime.Now,
            Health = health,
            HealthSummary = health.Message
        };

        _logger.LogInformation("Rendering home page in {Environment} with health {Status}", health.Environment,
            health.Status);

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
