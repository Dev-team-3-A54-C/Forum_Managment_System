using ForumManagmentSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Infrastructure.Repositories
{
    internal class UsersRepository
    {
        private readonly ApplicationContext context;

        public UsersRepository(ApplicationContext context)
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
            throw new NotImplementedException();
            // return users.ToList();;
        }
        public IList<UserDb> FilterBy(int id)
        {
            /*
            var result = GetUsers();
            result = FilterByName(result, filterParameters.Name);
            result = FilterByStyle(result, filterParameters.Style);
            result = FilterByMinAbv(result, filterParameters.MinAbv);
            result = FilterByMaxAbv(result, filterParameters.MaxAbv);
            result = SortBy(result, filterParameters.SortBy);
            result = Order(result, filterParameters.SortOrder);

            return result.ToList();
            */
            throw new NotImplementedException();
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
    }
}
