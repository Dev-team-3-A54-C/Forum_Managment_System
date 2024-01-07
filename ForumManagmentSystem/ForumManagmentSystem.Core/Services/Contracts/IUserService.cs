using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.QueryParameters;

namespace ForumManagmentSystem.Core.Services.Contracts
{
    public interface IUserService
    {
        UserResponseDTO CreateUser(string username, UserDTO user);
        IList<UserResponseDTO> GetAll();
        UserResponseDTO GetUser(string username);
        UserResponseDTO GetUser(Guid id);
        UserResponseDTO Update(Guid id, UserDTO user);
        void Delete(Guid id, string username);
        IList<UserResponseDTO> FilterBy(UserQueryParameters usersParams);

    }
}
