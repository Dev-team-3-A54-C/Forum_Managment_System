using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Core.Helpers
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
            /*
            try
            {
                return usersService.GetUser(id);
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException("Invalid id!");
            }
            */
            throw new NotImplementedException();
        }
    }
}
