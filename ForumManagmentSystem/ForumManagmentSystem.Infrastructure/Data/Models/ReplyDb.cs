using ForumManagmentSystem.Infrastructure.Data.Models.Contracts;


namespace ForumManagmentSystem.Infrastructure.Data.Models
{
    public class ReplyDb : ISoftDelete
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public virtual PostDb Post { get; set; }
        public Guid UserId { get; set; }
        public virtual UserDb User { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
