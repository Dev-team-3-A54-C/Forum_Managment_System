using ForumManagmentSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Infrastructure.Repositories.Contracts
{
    public interface IUsersRepository
    {
        IList<UserDb> GetAll();
        IList<UserDb> FilterBy(int id);
        UserDb GetById(int id);
        UserDb GetByName(string name);
        UserDb Create(UserDb newUser); // Register
        UserDb Update(int id, UserDb user);
        bool Delete(int id);
        bool UserExists(string name);
        int Count();

    }
}
