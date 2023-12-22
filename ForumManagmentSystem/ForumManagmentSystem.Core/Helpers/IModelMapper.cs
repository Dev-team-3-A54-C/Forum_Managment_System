using ForumManagmentSystem.Core.DTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Core.Helpers
{
    public interface IModelMapper
    {
        UserDb Map(UserDTO dto);
    }
}
