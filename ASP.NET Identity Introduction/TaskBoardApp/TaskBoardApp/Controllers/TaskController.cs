using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Data;
using TaskBoardApp.Models.CreateModels;
using System.Security.Claims;
using TaskBoardApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace TaskBoardApp.Controllers
{
	public class TaskController : Controller
	{
		private readonly TaskBoardAppContext context;

		public TaskController(TaskBoardAppContext context)
        {
			this.context = context;
        }

        [HttpGet]
		public IActionResult Create()
		{
			var task = new TaskCreateModel()
			{
				Boards = GetBoards()
			};
			return View(task);
		}

		[HttpPost]
		public IActionResult Create(TaskCreateModel task)
		{
			CreateTask(task);
			return RedirectToAction("All", "Board");
		}

		[HttpGet]
        public IActionResult Detail(int id)
		{
			var realTask = context.Tasks.Include(t => t.Board)
				.FirstOrDefault(t => t.Id == id);
			var user = context.Users.Find(realTask.OwnerId);

			TaskDetailViewModel task = new TaskDetailViewModel()
			{
				Id = id,
				Title = realTask.Title,
				Description = realTask.Description,
				Board = realTask.Board.Name,
				CreatedOn = realTask.CreatedOn,
				Owner = user.UserName
			};
			return View(task);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var task = context.Tasks.Find(id);

			TaskCreateModel taskModel = new TaskCreateModel()
			{
				Title = task.Title,
				Description = task.Description,
				BoardId = task.BoardId,
				Boards = GetBoards()
			};

			return View(taskModel);
		}

		[HttpPost]
		public IActionResult Edit(int id, TaskCreateModel taskModel)
		{
			var task = context.Tasks.Find(id);

			task.Title = taskModel.Title;
			task.Description = taskModel.Description;
			task.BoardId = taskModel.BoardId;
			context.SaveChanges();

			return RedirectToAction("All", "Board");
		}

		public IActionResult Delete(int id)
		{
			var task = context.Tasks.Remove(context.Tasks.Find(id));
			context.SaveChanges();

			return RedirectToAction("All", "Board");

		}
        private IEnumerable<BoardCreateModel> GetBoards()
		{
			return context.Boards.Select(b => new BoardCreateModel { Id = b.Id, Name = b.Name }).ToList();
		}

		private void CreateTask(TaskCreateModel task)
		{
			context.Tasks.Add(new Data.Models.Task()
			{
				Title = task.Title,
				Description = task.Description,
				BoardId = task.BoardId,
				OwnerId = GetUserId(),
				CreatedOn = DateTime.Now
			});

			context.SaveChanges();
		}

		private string GetUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
