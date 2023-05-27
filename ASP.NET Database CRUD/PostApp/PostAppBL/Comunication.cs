using Microsoft.EntityFrameworkCore;
using PostAppBL.Service;
using PostAppBL.ViewModel;
using PostAppDatabase;
using PostAppDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostAppBL
{
	public class Comunication : IComunication
	{

		private readonly PostAppContext context = new PostAppContext(new DbContextOptionsBuilder<PostAppContext>()
			.UseSqlServer("Server=.;Database=PostApp;Trusted_Connection=True;TrustServerCertificate=True;").Options);

		
		public async Task DeletePostAsync(int id)
		{
			context.Posts.Remove(await context.Posts.FindAsync(id));
			context.SaveChangesAsync();

			return;
		}

		public async Task EditPostAsync(int id, PostViewModel model)
		{
			var post = context.Posts.Find(id);
			post.Content = model.Content;
			post.Title = model.Title;

			context.SaveChangesAsync();

			return;
		}

		public async Task<List<PostViewModel>> GetAllPostsAsync()
		{
			return await context.Posts.Select(p => new PostViewModel
			{
				Id = p.Id,
				Title = p.Title,
				Content = p.Content,
			}).ToListAsync();
		}

		public async Task<PostViewModel> GetPostByIdAsync(int id)
		{
			var post = await context.Posts.FindAsync(id);

			var model = new PostViewModel()
			{
				Id = id,
				Title = post.Title,
				Content = post.Content,
			};

			return model;
		}

		public Task PostAsync(PostViewModel post)
		{
			context.Posts.Add(new Post
			{
				Title = post.Title,
				Content = post.Content,
			});

			context.SaveChangesAsync();
			return Task.CompletedTask;
		}
	}
}
