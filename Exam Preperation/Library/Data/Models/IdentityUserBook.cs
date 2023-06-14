using Library.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
	public class IdentityUserBook
	{
        [Required]
        public string CollectorId { get; set; }

        [Required]
        [ForeignKey(nameof(CollectorId))]
        public IdentityUser Collector { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
    }
}

//CollectorId – a string, Primary Key, foreign key (required)
//• Collector – IdentityUser
//• BookId – an integer, Primary Key, foreign key (required)
//• Book – Book
