using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Core.Helpers
{
    public class ModelMapper : IModelMapper
    {
        public UserDb Map(UserDTO dto)
        {
            return new UserDb
            {
                Username = dto.Username,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };
        }
    }
}
