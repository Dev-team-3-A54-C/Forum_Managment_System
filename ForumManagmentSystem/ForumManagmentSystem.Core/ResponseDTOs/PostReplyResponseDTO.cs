namespace ForumManagmentSystem.Core.ResponseDTOs
{
    public class PostReplyResponseDTO
    {
        public string ID { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LikesCount { get; set; }
    }
}
