using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumManagmentSystem.Core.DTOs;
using ForumManagmentSystem.Core.QueryParameters;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Core.Services
{
    public interface IUserService
    {
        UserDb CreateUser(string username, string password, UserDTO user);
        IList<UserResponseDTO> GetAll();
        UserResponseDTO GetUser(string username);
        UserResponseDTO GetUser(int id);
        UserDb Update(int id, UserDTO user);
        void Delete(int id, UserDb user);
        IList<UserDb> FilterBy(UserQueryParameters query);

    }
}
