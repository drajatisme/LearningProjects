using LearningProject.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace LearningProject.Controllers
{
    public class HomeController : Controller
    {
        // Standard Capturing category
        //private readonly ILogger<HomeController> _logger;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ILogger _logger;
        public HomeController(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger("Demo Category");
        }

        public IActionResult Index()
        {
            _logger.LogTrace("Trace Log");
            _logger.LogDebug("Debug Log");
            _logger.LogInformation($"Information Log");
            _logger.LogWarning($"Warning Log");
            _logger.LogError($"Error Log");
            _logger.LogCritical($"Critical Log");
            return View();
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

    public class LoggingId
    {
        public const int DemoCode = 1001;
    }
}