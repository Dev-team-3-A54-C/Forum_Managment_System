using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.QueryParameters;

namespace ForumManagmentSystem.Infrastructure.Repositories.Contracts
{
    public interface IUsersRepository
    {
        IList<UserDb> GetAll();
        IList<UserDb> FilterBy(UserQueryParameters usersParams);
        UserDb GetById(Guid id);
        UserDb GetByName(string name);
        UserDb Create(UserDb newUser); // Register
        UserDb Update(Guid id, UserDb user);
        UserDb Delete(Guid id);
        bool UserExists(string name);
        int Count();

    }
}
