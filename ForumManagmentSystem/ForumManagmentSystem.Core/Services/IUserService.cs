﻿using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.QueryParameters;

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
        IList<UserResponseDTO> FilterBy(UserQueryParameters usersParams);

    }
}
