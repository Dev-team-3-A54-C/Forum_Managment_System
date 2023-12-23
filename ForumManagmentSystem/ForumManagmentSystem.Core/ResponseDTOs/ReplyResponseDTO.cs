
namespace ForumManagmentSystem.Core.ResponseDTOs
{
    public class ReplyResponseDTO
    {
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        //possibly id
        public string PostTitle { get; set; }
        //id for post?
    }
}
