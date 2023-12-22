using ForumManagmentSystem.Core.DTOs;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Web.Exceptions;
using ForumManagmentSystem.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagmentSystem.Web.Controllers
{
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

        [HttpGet("")] // api/users/
        public IActionResult GetUsers()
        {
            var user = userService.GetAll();
            return Ok(user);
        }

        [HttpGet("{id}")] // api/users/{id}
        public IActionResult GetUser(int id)
        {
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
        }

        // Register
        [HttpPost("register")] // api/users/register
        public IActionResult CreateNewUser([FromHeader] string username, [FromBody] UserDTO dto)
        {
            throw new NotImplementedException();
        }

        // Login ?
        // Update ?

        [HttpDelete("{id}")] // api/users/{id}
        public IActionResult DeleteUser(int id, [FromHeader] string username)
        {
            throw new NotImplementedException();
        }
    }
}
