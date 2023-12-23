
using System.ComponentModel.DataAnnotations;

namespace ForumManagmentSystem.Core.RequestDTOs
{
    public class TagDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
