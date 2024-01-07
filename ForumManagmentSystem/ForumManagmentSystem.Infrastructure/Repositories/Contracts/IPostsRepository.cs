using ForumManagmentSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Infrastructure.Repositories.Contracts
{
    public interface IPostsRepository
    {
        IList<PostDb> GetAll();
        PostDb GetById(Guid id);
        PostDb GetByTitle(string title);
        PostDb Create(PostDb newPost); // Register
        PostDb Update(Guid id, PostDb post);
        bool Delete(Guid id);
        bool PostExists(string name);
        int Count();
        bool AddLike(PostLikesDb postLikes);
        bool RemoveLike(PostLikesDb postLikes);
    }
}
