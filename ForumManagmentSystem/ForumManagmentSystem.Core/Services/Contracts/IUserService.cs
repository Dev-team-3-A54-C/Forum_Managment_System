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
        UserResponseDTO Update(Guid id, EditUserDTO user);
        UserResponseDTO Block(Guid id, string username);
        UserResponseDTO Delete(Guid id, string username);
        IList<UserResponseDTO> FilterBy(UserQueryParameters usersParams);
        bool UserExists(string username);
        string Login(UserLoginDTO userDTO);
        UserDb GetDbUser(string username);
        bool IsCurrentUserAdmin(string currUsername);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
