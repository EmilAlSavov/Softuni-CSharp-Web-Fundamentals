using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
	public class BookController : BaseController
	{
		private LibraryDbContext context { get; set; }
		public BookController(LibraryDbContext context)
        {
			this.context = context;
        }

        public IActionResult All()
		{
			var books = context.Books
				.Select(b => new BookViewModel()
				{
					Id = b.Id,
					Title = b.Title,
					Description = b.Description,
					Author = b.Author,
					Category = b.Category.Name,
					ImageUrl = b.ImageUrl,
					Rating = b.Rating,
				}).ToList();

			return View(books);
		}

		public IActionResult Mine()
		{
			var books = context.IdentityUsersBooks
				.Where(ub => ub.CollectorId == GetUserId())
				.Select(ub => new BookViewModel()
				{
					Author = ub.Book.Author,
					Category = ub.Book.Category.Name,
					Description = ub.Book.Description,
					Id = ub.Book.Id,
					ImageUrl = ub.Book.ImageUrl,
					Rating = ub.Book.Rating,
					Title = ub.Book.Title,
				}).ToList();

			return View(books);
		}

		public IActionResult AddToCollection(int Id)
		{
			var book = context.Books.Find(Id);
			string userId = GetUserId();

			bool isAlreadyAdded = context.IdentityUsersBooks.Any(ub => ub.CollectorId == userId && ub.BookId == Id);

			if (book != null)
			{
				if(isAlreadyAdded == false)
				{
					context.IdentityUsersBooks.Add(new Data.Models.IdentityUserBook()
					{
						CollectorId = userId,
						BookId = Id,
					});

					context.SaveChanges();
				}
			}

			return RedirectToAction("All", "Book");
		}

		public IActionResult RemoveFromCollection(int Id)
		{
			string userId = GetUserId();

			var identityUser = context.IdentityUsersBooks.FirstOrDefault(ub => ub.CollectorId == userId && ub.BookId == Id);

			context.IdentityUsersBooks.Remove(identityUser);

			context.SaveChanges();

			return RedirectToAction("Mine", "Book");
		}

		[HttpGet]
		public IActionResult Add()
		{
			var book = new BookViewModel()
			{
				Categories = context.Categories.Select(c => new CategoryViewModel()
				{
					Id = c.Id,
					Name = c.Name,
				}).ToList()
			};

			return View(book);
		}

		[HttpPost]
		public IActionResult Add(BookViewModel model)
		{
			context.Books.Add(new Book()
			{
				Id = model.Id,
				Description = model.Description,
				Author = model.Author,
				ImageUrl = model.ImageUrl,
				Rating = model.Rating,
				Title = model.Title,
				CategoryId = model.CategoryId
			});

			context.SaveChanges();

			return RedirectToAction("All", "Book");
		}

		private string? GetUserId()
		{
			string? id = null;

			if(User != null)
			{
				id = User.FindFirstValue(ClaimTypes.NameIdentifier);
			}

			return id;
		}
	}
}
