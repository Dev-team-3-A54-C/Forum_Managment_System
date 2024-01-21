
using System.ComponentModel.DataAnnotations;

namespace ForumManagmentSystem.Core.RequestDTOs
{
    public class ReplyDTO
    {
        public string ID { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string PostTitle { get; set; }
        [Required]
        public string CreatedBy { get; set; }

    }
}
