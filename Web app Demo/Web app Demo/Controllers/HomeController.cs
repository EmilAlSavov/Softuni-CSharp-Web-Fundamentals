using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_app_Demo.Models;

namespace Web_app_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Hello World!";
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "This is ASP NET CORE MVC app.";
            return View();
        }

        public IActionResult Numbers(int end)
        {
            ViewBag.Start = 1;
            ViewBag.End = end;

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
}