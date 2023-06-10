
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.Task;

namespace TaskBoardApp.Models.CreateModels
{
	public class TaskCreateModel
	{
        [Required]
        [StringLength(TaskMaxTitle, MinimumLength = TaskMinTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TaskMaxDescription, MinimumLength = TaskMinDescription)]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        
        public IEnumerable<BoardCreateModel> Boards { get; set; } = null!;
    }
}
