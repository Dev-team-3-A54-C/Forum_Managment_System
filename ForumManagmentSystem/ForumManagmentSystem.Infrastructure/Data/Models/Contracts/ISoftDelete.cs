
namespace ForumManagmentSystem.Infrastructure.Data.Models.Contracts
{
    internal interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
