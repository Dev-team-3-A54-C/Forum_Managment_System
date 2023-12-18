
using System.ComponentModel.DataAnnotations;

namespace ForumManagmentSystem.Core.DTOs
{
    public class TagDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
