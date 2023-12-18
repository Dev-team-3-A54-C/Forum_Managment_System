using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumManagmentSystem.Core.ResponseDTOs;

namespace ForumManagmentSystem.Core.Services
{
    public interface IUserService
    {
        List<UserResponseDTO> GetAll();
        UserResponseDTO GetUser(string username, string password);
        UserResponseDTO GetUser(int id);

    }
}
