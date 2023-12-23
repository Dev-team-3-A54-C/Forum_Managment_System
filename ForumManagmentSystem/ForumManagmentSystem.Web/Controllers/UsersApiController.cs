
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Core.Exceptions;
using ForumManagmentSystem.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Infrastructure.QueryParameters;

namespace ForumManagmentSystem.Web.Controllers
{
    [ApiController]
    [Route("api/forum/users")]
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

        [HttpGet("")] 
        public IActionResult GetUsers([FromQuery] UserQueryParameters filterParameters)
        {

            var user = userService.FilterBy(filterParameters);
            return Ok(user);

        }

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

        // Register
        [HttpPost("register")] // api/users/register
        public IActionResult CreateNewUser([FromHeader] string username, [FromBody] UserDTO dto)
        {
            throw new NotImplementedException();
        }

        // Login ?
        // Update ?

        [HttpDelete("{id}")] // api/users/{id}
        public IActionResult DeleteUser(string id, [FromHeader] string username)
        {
            throw new NotImplementedException();
        }
    }
}
