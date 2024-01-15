using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Infrastructure.Repositories.Contracts
{
    public interface IPostsRepository
    {
        IList<PostDb> GetAll();
        PostDb GetById(Guid id);
        PostDb GetByTitle(string title);
        IEnumerable<PostDb> GetTopTenByComments();
        IEnumerable<PostDb> GetTopTenRecent();
        PostDb Create(PostDb newPost); // Register
        PostDb Update(Guid id, PostDb post);
        PostDb Delete(Guid id);
        bool PostExists(string name);
        int Count();
        bool AddLike(PostLikesDb postLikes);
        bool RemoveLike(PostLikesDb postLikes);
    }
}
