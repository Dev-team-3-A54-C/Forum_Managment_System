using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;

namespace ForumManagmentSystem.Core.Helpers
{
    public class AuthManager
    {
        private readonly IUsersRepository userRepository;

        public AuthManager(IUsersRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public virtual UserDb TryGetUser(string username)
        {

            try
            {
                return userRepository.GetByName(username);
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException("Invalid id!");
            }

            
        }

        public virtual UserDb TryGetUser(Guid id)
        {

            try
            {
                return userRepository.GetById(id);
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException("Invalid id!");
            }


        }
    }
}
