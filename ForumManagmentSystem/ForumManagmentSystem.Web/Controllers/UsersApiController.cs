using ForumManagmentSystem.Core.DTOs;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Core.Exceptions;
using ForumManagmentSystem.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.QueryParameters;

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
            
            var user = userService.GetAll();

            List<UserResponseDTO> users = userService
                .FilterBy(filterParameters);

            return Ok(user);
        }

        // READ Id: Get single User
        [HttpGet("{id}")] // api/users/{id}
        public IActionResult GetUser(string id)
        {
            throw new NotImplementedException();
            /*
            try
            {
                var user = userService.GetUser(id);
                // TODO: Resposne DTO           BeerResponseDto beerResponseDto = modelMapper.Map(beer);

                return Ok(user);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            */
        }

        // Create (Register): Creates a new user
        [HttpPost("register")] // api/users/register
        public IActionResult CreateNewUser([FromHeader] string username, [FromBody] UserDTO dto)
        {
            throw new NotImplementedException();
        }

        // Update: Update their profile
        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, [FromHeader] string username, [FromBody] UserDTO dto)
        {
            // Users should not be able to change their username once registered
            throw new NotImplementedException();
        }

        /*
         * Login
         * Logout
         * Block
         * Unblock
         */

        /*
            // Delete: Deletes user
            [HttpDelete("{id}")] // api/users/{id}
            public IActionResult DeleteUser(string id, [FromHeader] string username)
            {
                throw new NotImplementedException();
            }
        */
    }
}
