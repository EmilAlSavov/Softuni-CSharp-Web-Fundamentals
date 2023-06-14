using Library.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
	public class BookViewModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 10)]
		public string Title { get; set; } = null!;

		[Required]
		[StringLength(50, MinimumLength = 5)]
		public string Author { get; set; } = null!;


		[StringLength(5000, MinimumLength = 5)]
		public string Description { get; set; }

		[Required]
		public string ImageUrl { get; set; } = null!;


		[Range(0.0, 10.0)]
		public decimal Rating { get; set; }


		[Required]
		public string Category { get; set; } = null!;

        public int CategoryId { get; set; }

		public List<CategoryViewModel>? Categories { get; set; } = new List<CategoryViewModel>();
    }
}
