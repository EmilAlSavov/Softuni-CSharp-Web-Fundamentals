using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextSpliterApp.Models;
using TextSpliterApp.Models.TextSplitModels;

namespace TextSpliterApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private static TextViewModel Text = new TextViewModel()
		{
			SplitedText = " "
		};

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index(TextViewModel textViewModel)
		{
			return View(textViewModel);
		}

		[HttpPost]
		public IActionResult Split(TextViewModel textViewModel)
		{
            if (ModelState.GetFieldValidationState("Text") != Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
			{
				return RedirectToAction("Index", textViewModel);
			}
			textViewModel.SplitedText = textViewModel.Text.Replace(" ", Environment.NewLine);
			return RedirectToAction("Index", textViewModel);
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