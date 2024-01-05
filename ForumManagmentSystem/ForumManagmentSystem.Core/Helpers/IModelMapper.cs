using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Core.Helpers
{
    public interface IModelMapper
    {
        UserDb Map(UserDTO dto);
    }
}
