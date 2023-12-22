using ForumManagmentSystem.Infrastructure.Data.Models.Contracts;


namespace ForumManagmentSystem.Infrastructure.Data.Models
{
    public class TagDb : ISoftDelete
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public virtual ICollection<PostTagsDb> Posts { get; set; } = new HashSet<PostTagsDb>();
    }
}
