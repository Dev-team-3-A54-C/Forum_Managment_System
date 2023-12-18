using ForumManagmentSystem.Infrastructure.Data.Models.Contracts;


namespace ForumManagmentSystem.Infrastructure.Data.Models
{
    public class UserDb : ISoftDelete
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<PostDb> Posts { get; set; } = new HashSet<PostDb>();
        public bool IsDeleted { get; set; }
    }
}
