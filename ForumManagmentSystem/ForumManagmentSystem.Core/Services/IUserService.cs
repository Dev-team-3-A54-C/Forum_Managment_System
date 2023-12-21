using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Core.Services
{
    public interface IUserService
    {
        UserDb CreateUser(string username, string password, string email);
        List<UserResponseDTO> GetAll();
        UserResponseDTO GetUser(string username, string password);
        UserResponseDTO GetUser(int id);
        UserDb Update(int id, UserDb user);
        void Delete(int id, UserDb user);

    }
}
