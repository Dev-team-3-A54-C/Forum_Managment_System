using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Infrastructure.QueryParameters;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Data.Models;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace ForumManagmentSystem.Web.Controllers.API
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UsersApiController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IModelMapper modelMapper;
        private readonly AuthManager authManager;
        private readonly IConfiguration configuration;

        public static UserDb user = new UserDb();

        public UsersApiController
            (IUserService userService, IModelMapper modelMapper, AuthManager authManager, IConfiguration configuration)
        {
            this.userService = userService;
            this.modelMapper = modelMapper;
            this.authManager = authManager;
            this.configuration = configuration;
        }

        // READ All: Get all Users or filter by parameters
        [HttpGet("")] // api/users/
        public IActionResult GetUsers([FromHeader] string authorization,[FromQuery] UserQueryParameters filterParameters)
        {
            

            IList<UserResponseDTO> users = userService
                .FilterBy(filterParameters);

            return Ok(users);
        }

        // READ Id: Get single User
        [HttpGet("{id}")] // api/users/{id}
        public IActionResult GetUser(string id)
        {
            try
            {
                var user = userService.GetUser(new Guid(id));
                return Ok(user);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDb>> Register([FromBody] UserDTO requestDTO)
        {
            try
            {
                UserResponseDTO newUser = userService.CreateUser(requestDTO);
                return Ok(newUser);
            }
            catch(NameDuplicationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login([FromBody] UserDTO requestDTO)
        {
            try
            {
                string token = userService.Login(requestDTO);
                return Ok(token);
            }
            catch(WrongPasswordException e)
            {
                return BadRequest(e.Message);
            }
            catch(EntityNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        // Update: Update their profile
        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, [FromHeader] string username, [FromBody] UserDTO dto)
        {
            //Users should not be able to change their username once registered
            try
            {
                UserResponseDTO result = userService.Update(new Guid(id), dto);
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /*
         * Login
         * Logout
         * Block
         * Unblock
         */


        // Delete: Deletes user
        [HttpDelete("{id}")] // api/users/{id}
        public IActionResult DeleteUser(string id, [FromHeader] string username)
        {
            try
            {
                userService.Delete(new Guid(id), username);
                return Ok($"User with id:[{id}] deleted successfully.");
            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

    }
}
