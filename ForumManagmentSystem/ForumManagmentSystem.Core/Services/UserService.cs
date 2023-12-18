using ForumManagmentSystem.Core.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Core.Services
{
    public class UserService : IUserService
    {
        public List<UserResponseDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserResponseDTO GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public UserResponseDTO GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
