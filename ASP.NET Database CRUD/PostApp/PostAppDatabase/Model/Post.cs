using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostAppDatabase.Model
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Title { get; set; } = null!;

        [MaxLength(1000)]
        [Required]
        public string Content { get; set; } = null!;
    }
}
