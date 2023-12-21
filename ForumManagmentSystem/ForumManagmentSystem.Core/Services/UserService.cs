using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository usersRepository;
        public UserService(IUsersRepository uRep)
        {
            usersRepository = uRep;
        }

        public UserDb CreateUser(UserDb u)
        {

            usersRepository.Create(u);
        }

        public List<UserResponseDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserResponseDTO GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public UserResponseDTO GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public UserDb Update(int id, UserDb user)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id, UserDb user)
        {
            throw new NotImplementedException();
        }
    }
}
