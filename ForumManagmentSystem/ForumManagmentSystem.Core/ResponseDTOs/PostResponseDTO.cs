
namespace ForumManagmentSystem.Core.ResponseDTOs
{
    public class PostResponseDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public string Username { get; set; }

        //possibly id for user?
    }
}
