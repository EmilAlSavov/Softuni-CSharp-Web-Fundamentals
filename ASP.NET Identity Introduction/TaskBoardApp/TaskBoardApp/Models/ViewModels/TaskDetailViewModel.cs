namespace TaskBoardApp.Models.ViewModels
{
	public class TaskDetailViewModel
	{
        public int Id { get; set; }
        public string Title { get; set; }

		public string Description { get; set; }

        public string Owner { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Board { get; set; }
    }
}
