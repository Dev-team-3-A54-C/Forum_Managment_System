using ForumManagmentSystem.Infrastructure.Data;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.QueryParameters;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly FMSContext context;

        public UsersRepository(FMSContext context)
        {
            this.context = context;
        }

        private IQueryable<UserDb> GetUsers()
        {
            /*
            return context.Beers
                    .Include(beer => beer.Style)
                    .Include(beer => beer.CreatedBy)
                    .Include(beer => beer.Ratings)
                        .ThenInclude(rating => rating.User);
            */

            throw new NotImplementedException();
        }

        public IList<UserDb> GetAll()
        {
            return context.Users.ToList();
        }
        public IList<UserDb> FilterBy(UserQueryParameters usersParams)
        {
            IQueryable<UserDb> result = context.Users;

            if (!string.IsNullOrEmpty(usersParams.Username))
            {
                result = result.Where(user => user.Username.Contains(usersParams.Username));
            }

            if (!string.IsNullOrEmpty(usersParams.FirstName))
            {
                result = result.Where(user => user.FirstName == usersParams.FirstName);
            }

            if (!string.IsNullOrEmpty(usersParams.Email))
            {
                result = result.Where(user => user.Email == usersParams.Email);
            }

            return result.ToList();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public PostDb Create(PostDb newUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserDb GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserDb GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public PostDb Update(int id, PostDb beer)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string name)
        {
            throw new NotImplementedException();
        }

        public UserDb Create(UserDb newUser)
        {
            throw new NotImplementedException();
        }

        public UserDb Update(int id, UserDb user)
        {
            throw new NotImplementedException();
        }
    }
}
