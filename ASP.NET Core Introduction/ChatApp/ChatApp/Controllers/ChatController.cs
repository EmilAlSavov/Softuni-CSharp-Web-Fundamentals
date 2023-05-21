using ChatApp.Models.ChatModels;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private static ChatViewModel chatViewModel = new ChatViewModel()
        {
            CurrentMessage = new MessageViewModel(),
            Messages = new List<MessageViewModel>()
        };
        public IActionResult Show()
        {
            return View(chatViewModel);
        }

        [HttpPost]
        public IActionResult Send(MessageViewModel messageViewModel)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Show");
            }
            chatViewModel.Messages.Add(messageViewModel);

            return RedirectToAction("Show");
        }
    }
}
