using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Web_app_Demo.Models.Product;

namespace Web_app_Demo.Controllers
{
	public class ProductController : Controller
	{
		private List<ProductViewModel> products = new List<ProductViewModel>()
		{
			new ProductViewModel()
			{
				Id = 1,
				Name = "Cheese",
				Price = 7.00
			},
			new ProductViewModel()
			{
				Id = 2,
				Name = "Ham",
				Price = 5.50
			},
			new ProductViewModel()
			{
				Id = 3,
				Name = "Bread",
				Price = 1.50
			}
		};
		public IActionResult AllProducts(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return View(products);
			}

            var productsByName = products.Where(p => p.Name.ToLower().Contains(name.ToLower()));

            return View(productsByName);
        }


        public IActionResult ById(int id)
		{
			var product = products.FirstOrDefault(x => x.Id == id);

			if (product == null)
			{
				return BadRequest();
			}

			return View(product);
		}

		public IActionResult AllAsJson()
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true,
			};
			return Json(products, options);
		}

		
	}
}
