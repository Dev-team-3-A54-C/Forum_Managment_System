
using System.ComponentModel.DataAnnotations;

namespace ForumManagmentSystem.Core.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [MaxLength(32, ErrorMessage = "The {0} must be no more than {1} characters long.")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [MaxLength(32, ErrorMessage = "The {0} must be no more than {1} characters long.")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
