
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Core.ResponseDTOs
{
    public class PostResponseDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<PostReplyResponseDTO/*ReplyDb*/> Replies { get; set; } = new HashSet<PostReplyResponseDTO>();

        //possibly id for user?
    }
}
