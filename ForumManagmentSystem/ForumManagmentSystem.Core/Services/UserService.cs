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
using ForumManagmentSystem.Infrastructure.Exceptions;
using AutoMapper;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Core.Helpers.MappingConfig;

namespace ForumManagmentSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository usersRepository;
        private readonly IMapper autoMapper;
        public UserService(IUsersRepository uRep, IMapper mapper)
        {
            usersRepository = uRep;
            autoMapper = mapper;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PostProfile>();
            });
            autoMapper = config.CreateMapper();
        }

        public UserResponseDTO CreateUser(string username, UserDTO user)
        {
            //UserDb userDb = new UserDb();
            //userDb.Username = username;
            //userDb.Password = password;
            //userDb.Email = user.Email;
            //userDb.CreatedOn = DateTime.Now;
            //userDb.FirstName = user.FirstName;
            //userDb.LastName = user.LastName;
            
            //TODO: map to UserResponseDTO
            UserDb userDb = autoMapper.Map<UserDb>(user); // temporary stuff
            return autoMapper.Map<UserResponseDTO>(usersRepository.Create(userDb));
        }

        public IList<UserResponseDTO> GetAll()
        {
            //TODO automapper
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
            //TODO Automapper
            UserResponseDTO response = new UserResponseDTO();
            UserDb user = usersRepository.GetByName(username);
            response.Username = user.Username;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            return response;
        }

        public UserResponseDTO GetUser(Guid id)
        {
            //TODO: auto mapper
            UserResponseDTO response = new UserResponseDTO();
            UserDb user = usersRepository.GetById(id);
            response.Username = user.Username;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            return response;
        }

        public UserResponseDTO Update(Guid id, UserDTO user)
        {
            UserDb temp = usersRepository.GetByName(user.Username);
            //TODO: map to UserResponseDTO
            return autoMapper.Map<UserResponseDTO>(usersRepository.Update(id, temp)); //temporary
        }
        public void Delete(Guid id, string username)
        {
            UserDb user = usersRepository.GetByName(username);
            if(!user.IsAdmin)
            {
                throw new UnauthorizedOperationException($"User is not authorized.");
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
