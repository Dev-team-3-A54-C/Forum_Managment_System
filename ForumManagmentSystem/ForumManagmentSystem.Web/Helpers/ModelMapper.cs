using ForumManagmentSystem.Core.DTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Web.Helpers
{
    public class ModelMapper : IModelMapper
    {
        public UserDb Map(UserDTO dto)
        {
            return new UserDb
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };
        }
    }
}
