
namespace ForumManagmentSystem.Infrastructure.Data.Models
{
    public class PostTagsDb
    {
        public Guid PostId { get; set; }
        public PostDb Post { get; set; }
        public Guid TagId { get; set; }
        public TagDb Tag { get; set; }
    }
}
