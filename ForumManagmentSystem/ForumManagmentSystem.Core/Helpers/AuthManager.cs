using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;

namespace ForumManagmentSystem.Core.Helpers
{
    public class AuthManager
    {
        private readonly IUserService userService;

        //TODO: Need revisiting, it is temporary solution.


        public AuthManager(IUserService userService)
        {
            this.userService = userService;
        }

        public virtual UserResponseDTO TryGetUser(string username)
        {

            try
            {
                return userService.GetUser(username);
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException("Invalid id!");
            }

            
        }

        public virtual UserResponseDTO TryGetUser(Guid id)
        {

            try
            {
                return userService.GetUser(id);
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException("Invalid id!");
            }


        }
    }
}
