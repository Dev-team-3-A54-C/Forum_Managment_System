
namespace ForumManagmentSystem.Core.ResponseDTOs
{
    public class PostResponseDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public string CreatedBy { get; set; }

        //public ICollection<ReplyResponseDTO> Replies { get; set; }

        //possibly id for user?
    }
}
