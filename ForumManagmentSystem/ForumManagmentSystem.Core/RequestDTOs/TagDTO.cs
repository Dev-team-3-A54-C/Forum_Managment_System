
using System.ComponentModel.DataAnnotations;

namespace ForumManagmentSystem.Core.RequestDTOs
{
    public class TagDTO
    {
        //public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
