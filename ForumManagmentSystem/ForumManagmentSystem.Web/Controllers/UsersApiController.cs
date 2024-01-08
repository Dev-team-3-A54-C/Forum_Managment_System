using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Infrastructure.QueryParameters;
using ForumManagmentSystem.Core.Services.Contracts;

namespace ForumManagmentSystem.Web.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersApiController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IModelMapper modelMapper;
        private readonly AuthManager authManager;

        public UsersApiController(IUserService userService, IModelMapper modelMapper, AuthManager authManager)
        {
            this.userService = userService;
            this.modelMapper = modelMapper;
            this.authManager = authManager;
        }

        // READ All: Get all Users or filter by parameters
        [HttpGet("")] // api/users/
        public IActionResult GetUsers([FromQuery] UserQueryParameters filterParameters)
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

        // Create (Register): Creates a new user
        [HttpPost("register")] // api/users/register
        public IActionResult CreateNewUser([FromHeader] string username, [FromBody] UserDTO dto)
        {
            try
            {
                UserResponseDTO result = userService.CreateUser(username, dto);
                return Ok(result);
            }
            catch(NameDuplicationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // Update: Update their profile
        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, [FromHeader] string username, [FromBody] UserDTO dto)
        {
            // TODO: Users should not be able to change their username once registered
            try
            {
                UserResponseDTO result = userService.Update(new Guid(id), dto);
                return Ok(result);
            }
            catch(EntityNotFoundException ex)
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
            catch(UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

    }
}
