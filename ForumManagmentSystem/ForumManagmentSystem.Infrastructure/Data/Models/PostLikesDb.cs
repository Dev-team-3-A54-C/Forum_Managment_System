
namespace ForumManagmentSystem.Infrastructure.Data.Models
{
    public class PostLikesDb
    {
        public Guid PostId { get; set; }
        public PostDb Post { get; set; }
        public Guid UserId { get; set; }
        public UserDb User { get; set; }
    }
}
