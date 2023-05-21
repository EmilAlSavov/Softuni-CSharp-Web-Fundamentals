using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models.ChatModels
{
    public class MessageViewModel
    {
        [Required(ErrorMessage = "Field cannot be empty!")]
        public string Sender { get; set; }

        [Required(ErrorMessage = "Field cannot be empty!")]
        public string Message { get; set; }
    }
}
