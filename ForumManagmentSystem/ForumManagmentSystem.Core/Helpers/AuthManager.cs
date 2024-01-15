using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using System.Text;

namespace ForumManagmentSystem.Core.Helpers
{
    public class AuthManager
    {
		private const string InvalidCredentialsErrorMessage = "Invalid credentials!";
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

        public virtual UserDb TryGetUser(string username, string password)
        {

			try
			{
				var user = userService.GetDbUser(username);

                if (!userService.VerifyPasswordHash(password,
                user.PasswordHash, user.PasswordSalt))
                {
                    throw new WrongPasswordException(InvalidCredentialsErrorMessage);
                }

                return user;
			}
			catch (EntityNotFoundException)
			{
				throw new UnauthorizedOperationException(InvalidCredentialsErrorMessage);
			}
		}

    }
}
