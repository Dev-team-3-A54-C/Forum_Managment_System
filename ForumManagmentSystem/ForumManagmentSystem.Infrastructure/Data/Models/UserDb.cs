using ForumManagmentSystem.Infrastructure.Data.Models.Contracts;


namespace ForumManagmentSystem.Infrastructure.Data.Models
{
    public class UserDb : ISoftDelete
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
        public virtual ICollection<PostDb> LikedPosts { get; set; } = new HashSet<PostDb>();
        public virtual ICollection<PostDb> MyPosts { get; set; } = new HashSet<PostDb>();
        public virtual ICollection<ReplyDb> MyReplies { get; set; } = new HashSet<ReplyDb>();
    }
}
