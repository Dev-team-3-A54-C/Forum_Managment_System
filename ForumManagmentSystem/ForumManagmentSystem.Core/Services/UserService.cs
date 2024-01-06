using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ForumManagmentSystem.Infrastructure.QueryParameters;

namespace ForumManagmentSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository usersRepository;
        public UserService(IUsersRepository uRep)
        {
            usersRepository = uRep;
        }

        public UserDb CreateUser(string username, string password, UserDTO user)
        {
            UserDb userDb = new UserDb();
            userDb.Username = username;
            userDb.Password = password;
            userDb.Email = user.Email;
            userDb.CreatedOn = DateTime.Now;
            userDb.FirstName = user.FirstName;
            userDb.LastName = user.LastName;

            return usersRepository.Create(userDb);
        }

        public IList<UserResponseDTO> GetAll()
        {
            return usersRepository.GetAll()
                .Select(x => new UserResponseDTO()
                {
                    Username = x.Username,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToList();
        }

        public UserResponseDTO GetUser(string username)
        {
            UserResponseDTO response = new UserResponseDTO();
            UserDb user = usersRepository.GetByName(username);
            response.Username = user.Username;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            return response;
        }

        public UserResponseDTO GetUser(Guid id)
        {
            UserResponseDTO response = new UserResponseDTO();
            UserDb user = usersRepository.GetById(id);
            response.Username = user.Username;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            return response;
        }

        public UserDb Update(Guid id, UserDTO user)
        {
            UserDb temp = usersRepository.GetByName(user.Username);
            return usersRepository.Update(id, temp);
        }
        public void Delete(Guid id, UserDb u)
        {
            if(!u.IsAdmin)
            {
                throw new (); // switch to custom exception
            }
            usersRepository.Delete(id);
        }

        public IList<UserResponseDTO> FilterBy(UserQueryParameters usersParams)
        {
            //TODO use automapper
            return usersRepository.FilterBy(usersParams)
                .Select(x => new UserResponseDTO
                {
                    Username = x.Username,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                }).ToList();
        }
    }
}
