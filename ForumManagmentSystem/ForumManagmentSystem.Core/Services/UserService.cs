using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
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
        }

        public UserResponseDTO CreateUser(string username, UserDTO user)
        {
            UserDb userDb = autoMapper.Map<UserDb>(user);
            return autoMapper.Map<UserResponseDTO>(usersRepository.Create(userDb));
        }

        public IList<UserResponseDTO> GetAll()
        {
            return usersRepository.GetAll()
                .Select(u => autoMapper.Map<UserResponseDTO>(u))
                .ToList();
        }

        public UserResponseDTO GetUser(string username)
        {
            return autoMapper.Map<UserResponseDTO>(usersRepository.GetByName(username));
        }

        public UserResponseDTO GetUser(Guid id)
        {
            return autoMapper.Map<UserResponseDTO>(usersRepository.GetById(id));
        }

        public UserResponseDTO Update(Guid id, UserDTO user)
        {
            if(user.Username != null)
            {
                throw new CannotChangeUsernameException
                    ("Username cannot be changed once registered.");
            }
            return autoMapper.Map<UserResponseDTO>
                (usersRepository.Update(id, autoMapper.Map<UserDb>(user)));
        }
        public UserResponseDTO Delete(Guid id, string username)
        {
            UserDb user = usersRepository.GetByName(username);
            if(!user.IsAdmin)
            {
                throw new UnauthorizedOperationException($"User is not authorized.");
            }
            return autoMapper.Map<UserResponseDTO>(usersRepository.Delete(id));
        }

        public IList<UserResponseDTO> FilterBy(UserQueryParameters usersParams)
        {
            return usersRepository.FilterBy(usersParams)
                .Select(x => autoMapper.Map<UserResponseDTO>(x))
                .ToList(); 
        }
    }
}
