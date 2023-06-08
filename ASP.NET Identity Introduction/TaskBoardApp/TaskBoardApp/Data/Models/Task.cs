using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Data.DataConstants.Task;

namespace TaskBoardApp.Data.Models
{
    public class Task
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TaskMaxTitle, MinimumLength = TaskMinTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TaskMaxDescription, MinimumLength = TaskMinDescription)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Board))]
        public int BoardId { get; set; }

        public Board Board { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;
    }
}
