
using System.ComponentModel.DataAnnotations;

namespace ForumManagmentSystem.Core.RequestDTOs
{
    public class ReplyDTO
    {
        [Required]
        public string Content { get; set; }
    }
}
