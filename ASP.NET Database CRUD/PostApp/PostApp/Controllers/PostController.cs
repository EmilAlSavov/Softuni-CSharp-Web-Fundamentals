using Microsoft.AspNetCore.Mvc;
using PostAppBL;
using PostAppBL.ViewModel;

namespace PostApp.Controllers
{
	public class PostController : Controller
	{
		private readonly Comunication comunication = new Comunication();
		public async Task<IActionResult> Index()
		{
			var models = await comunication.GetAllPostsAsync();

			return View("All", models);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]

		public async Task<IActionResult> Add(PostViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			comunication.PostAsync(model);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var model = await comunication.GetPostByIdAsync(id);

			if(!ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, PostViewModel model)
		{
			if(!ModelState.IsValid)
			{
				return View(model);
			}

			await comunication.EditPostAsync(id, model);

			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			comunication.DeletePostAsync(id);
			return RedirectToAction("Index");
		}
	}
}
