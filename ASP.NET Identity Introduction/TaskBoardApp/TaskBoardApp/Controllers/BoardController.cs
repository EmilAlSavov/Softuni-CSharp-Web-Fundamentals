using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Data;
using TaskBoardApp.Models.ViewModels;

namespace TaskBoardApp.Controllers
{
    public class BoardController : Controller
    {
        private readonly TaskBoardAppContext context;

        public BoardController(TaskBoardAppContext context)
        {
            this.context = context;
        }

        public IActionResult All()
        {
            var boards = context.Boards.Select(b => new BoardViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Tasks = b.Tasks.Select(t => new TaskViewModel
                {
                    Title = t.Title,
                    Description = t.Description,
                    Id = t.Id,
                    Owner = t.OwnerId
                })
            }).ToList();

            return View(boards);
        }
    }
}
