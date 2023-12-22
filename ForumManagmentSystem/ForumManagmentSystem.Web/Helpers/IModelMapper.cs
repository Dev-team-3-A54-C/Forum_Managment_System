using ForumManagmentSystem.Core.DTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Web.Helpers
{
    public interface IModelMapper
    {
        UserDb Map(UserDTO dto);
    }
}
