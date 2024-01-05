using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Infrastructure.Repositories.Contracts
{
    public interface ITagRepository
    {
        TagDb GetByName(string name);
        IEnumerable<TagDb> GetAll();
        TagDb Create(string name);
        TagDb Update(string name);
        TagDb Delete(string name);
    }
}
