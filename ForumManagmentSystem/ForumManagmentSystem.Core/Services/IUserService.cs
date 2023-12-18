using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumManagmentSystem.Infrastructure;

namespace ForumManagmentSystem.Core.Services
{
    public interface IUserService
    {
        List<UserDb> GetAll();
        void GetUser(string username, string password);
        void GetUser(int id);
    }
}
