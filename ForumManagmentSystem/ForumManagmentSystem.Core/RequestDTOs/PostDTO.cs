
using System.ComponentModel.DataAnnotations;

namespace ForumManagmentSystem.Core.RequestDTOs
{
    public class PostDTO
    {
        [Required]
        [MinLength(16, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [MaxLength(64, ErrorMessage = "The {0} must be no more than {1} characters long.")]
        public string Title { get; set; }

        [Required]
        [MinLength(32, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [MaxLength(8192, ErrorMessage = "The {0} must be no more than {1} characters long.")]
        public string Content { get; set; }
    }
}
