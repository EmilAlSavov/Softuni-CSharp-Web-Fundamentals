using PostAppBL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostAppBL.Service
{
	internal interface IComunication
	{
		Task<List<PostViewModel>> GetAllPostsAsync();

		Task PostAsync(PostViewModel post);
		Task EditPostAsync(int id, PostViewModel model);

		Task DeletePostAsync(int id);

		Task<PostViewModel> GetPostByIdAsync(int id);
	}
}
