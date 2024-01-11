using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.QueryParameters;

namespace ForumManagmentSystem.Core.Services.Contracts
{
    public interface IUserService
    {
        UserResponseDTO CreateUser(UserDTO user);
        IList<UserResponseDTO> GetAll();
        int GetCount();
        UserResponseDTO GetUser(string username);
        UserResponseDTO GetUser(Guid id);
        UserResponseDTO Update(Guid id, UserDTO user);
        UserResponseDTO Delete(Guid id, string username);
        IList<UserResponseDTO> FilterBy(UserQueryParameters usersParams);
        bool UserExists(string username);
        string Login(UserDTO userDTO);
    }
}
