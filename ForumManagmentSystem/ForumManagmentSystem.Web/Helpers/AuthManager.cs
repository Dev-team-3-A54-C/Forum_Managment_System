using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Web.Exceptions;

namespace ForumManagmentSystem.Web.Helpers
{
    public class AuthManager
    {
        private readonly IUserService usersService;

        public AuthManager(IUserService usersService)
        {
            this.usersService = usersService;
        }

        public virtual UserDb TryGetUser(int id)
        {
            try
            {
                return usersService.GetUser(id);
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException("Invalid id!");
            }
        }
    }
}
