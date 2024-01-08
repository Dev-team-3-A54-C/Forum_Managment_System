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
using ForumManagmentSystem.Infrastructure.Exceptions;

namespace ForumManagmentSystem.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly FMSContext context;

        public UsersRepository(FMSContext context)
        {
            this.context = context;
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
        public UserDb GetById(Guid id)
        {
            return context.Users.Include(u => u.LikedPosts).FirstOrDefault(u => u.Id == id) ??
                throw new EntityNotFoundException($"User with id:{id} not found.");
        }

        public UserDb GetByName(string name)
        {
            return context.Users.FirstOrDefault(u => u.Username == name) ??
                throw new EntityNotFoundException($"User with username:{name} is not found.");
        }
        public UserDb Create(UserDb newUser)
        {
            context.Users.Add(newUser);
            context.SaveChanges();
            return newUser;
        }

        public UserDb Update(Guid id, UserDb user)
        {
            UserDb userToUpdate = context.Users.FirstOrDefault(u => u.Id == id) ??
                throw new EntityNotFoundException($"User to update with id:{id} not found.");
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            userToUpdate.Username = user.Username;

            context.SaveChanges();
            return userToUpdate;
        }
        public bool Delete(Guid id)
        {
            UserDb toDelete = GetById(id);
            context.Remove(toDelete);
            context.SaveChanges();
            if (toDelete.IsDeleted)
            {
                return true;
            }
            return false;
        }
        public bool UserExists(string name)
        {
            return context.Users.Any(u => u.Username == name);
        }
        public int Count()
        {
            return context.Users.Count();
        }  
    }
}
