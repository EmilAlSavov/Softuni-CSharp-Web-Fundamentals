using Microsoft.AspNetCore.Mvc;
using ProductShopApp.Models;
using ProductShopBL;
using System.Diagnostics;

namespace ProductShopApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private Communicator communicator = new Communicator();
        public IActionResult Index()
        {
            var test = communicator.Test();
            ViewBag.Test = test;
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