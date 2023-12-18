
using System.ComponentModel.DataAnnotations;

namespace ForumManagmentSystem.Core.DTOs
{
    public class ReplyDTO
    {
        [Required]
        public string Content { get; set; }
    }
}
