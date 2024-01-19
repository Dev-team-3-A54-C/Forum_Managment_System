using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using ForumManagmentSystem.Infrastructure.QueryParameters;
using ForumManagmentSystem.Infrastructure.Exceptions;
using AutoMapper;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Core.Helpers.MappingConfig;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ForumManagmentSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository usersRepository;
        private readonly IMapper autoMapper;
        private readonly IConfiguration configuration;
        public UserService(IUsersRepository uRep, IMapper mapper, IConfiguration configuration)
        {
            usersRepository = uRep;
            autoMapper = mapper;
            this.configuration = configuration;
        }

        public UserResponseDTO CreateUser(UserDTO user)
        {
            if(usersRepository.UserExists(user.Username))
            {
                throw new NameDuplicationException($"User with name {user.Username} already exists.");
            }
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            UserDb userDb = autoMapper.Map<UserDb>(user);
            userDb.PasswordSalt = passwordSalt;
            userDb.PasswordHash = passwordHash;
            userDb.CreatedOn = DateTime.Now;
            return autoMapper.Map<UserResponseDTO>(usersRepository.Create(userDb));
        }

        public IList<UserResponseDTO> GetAll()
        {
            return usersRepository.GetAll()
                .Select(u => autoMapper.Map<UserResponseDTO>(u))
                .ToList();
        }

        public int GetCount()
        {
            return usersRepository.Count();
        }

        public UserResponseDTO GetUser(string username)
        {
            return autoMapper.Map<UserResponseDTO>(usersRepository.GetByName(username));
        }

        public UserDb GetDbUser(string username)
		{
            return usersRepository.GetByName(username);
		}

		public UserResponseDTO GetUser(Guid id)
        {
            return autoMapper.Map<UserResponseDTO>(usersRepository.GetById(id));
        }

        public bool IsCurrentUserAdmin(string currUsername)
        {
            return usersRepository.GetByName(currUsername).IsAdmin;
        }

        public UserResponseDTO Update(Guid id, EditUserDTO user)
        {

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
        public bool UserExists(string username)
        {
            return usersRepository.UserExists(username);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public string Login(UserLoginDTO userDTO)
        {
            if (!usersRepository.UserExists(userDTO.Username))
            {
                throw new EntityNotFoundException("User not found.");
            }
            UserDb registeredUser = usersRepository.GetByName(userDTO.Username);
            if(!VerifyPasswordHash(userDTO.Password,
                registeredUser.PasswordHash, registeredUser.PasswordSalt))
            {
                throw new WrongPasswordException("Wrong password");
            }

            
            var token = CreateToken(registeredUser);
            return token;
        }
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(UserDb user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

    }
}
