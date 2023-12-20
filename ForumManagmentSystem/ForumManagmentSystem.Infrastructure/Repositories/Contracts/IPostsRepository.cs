using ForumManagmentSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Infrastructure.Repositories.Contracts
{
    internal interface IPostsRepository
    {
        IList<PostDb> GetAll();
        PostDb GetById(int id);
        PostDb GetByName(string name);
        PostDb Create(PostDb newUser); // Register
        PostDb Update(int id, PostDb beer);
        bool Delete(int id);
        bool PostExists(string name);
        int Count();
    }
}
