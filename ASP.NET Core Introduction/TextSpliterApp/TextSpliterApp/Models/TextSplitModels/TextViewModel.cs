using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TextSpliterApp.Models.TextSplitModels
{
	public class TextViewModel
	{
		[StringLength(30, MinimumLength = 2)]
		[Required]
        public string Text { get; set; }

		public string SplitedText { get; set; }
    }
}
