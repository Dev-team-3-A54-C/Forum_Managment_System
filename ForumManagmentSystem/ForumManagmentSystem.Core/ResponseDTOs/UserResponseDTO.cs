
namespace ForumManagmentSystem.Core.ResponseDTOs
{
    public class UserResponseDTO
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedOn { get; set; }

        //public ICollection<PostResponseDTO> MyPosts { get; set; }
        //maybe add collection for user liked posts and/or replies
    }
}
