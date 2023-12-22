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
        PostDb GetById(int id);
        PostDb GetByName(string name);
        PostDb Create(PostDb newPost); // Register
        PostDb Update(int id, PostDb post);
        bool Delete(int id);
        bool PostExists(string name);
        int Count();
    }
}
