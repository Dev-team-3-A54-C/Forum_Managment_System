using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.Services.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace ForumManagmentSystem.Web.Controllers.API
{
    [ApiController]
    [Route("api/posts")]
    [Authorize]
    public class PostsApiController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly IUserService userService;
        private readonly IModelMapper modelMapper;
        private readonly AuthManager authManager;

        public PostsApiController(IPostService postService, IUserService userS, IModelMapper modelMapper, AuthManager authManager)
        {
            this.postService = postService;
            this.modelMapper = modelMapper;
            this.authManager = authManager;
            userService = userS;
        }

        // Read: Gets all posts
        [HttpGet("")] // api/posts/
        public IActionResult GetPosts()
        {
            var posts = postService.GetAll();
            return Ok(posts);
        }

        // Read: Gets a single post
        [HttpGet("{id}")] // api/users/{id}
        public IActionResult GetPost(string id, [FromHeader] string username)
        {
            try
            {
                PostResponseDTO post = postService.Get(id);
                return Ok(post);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Read: Gets top ten posts by comments
        [HttpGet("Top10PostsByComments")]// api/posts/Top10PostsByComments
        [AllowAnonymous]
        public IActionResult GetTop10ByComments()
        {
            var posts = postService.GetTopTenByComments();
            return Ok(posts);
        }

        //Read: Gets top ten posts by comments
        [HttpGet("Top10NewestPosts")]// api/posts/Top10NewestPosts
        [AllowAnonymous]
        public IActionResult GetTop10Newest()
        {
            var posts = postService.GetTopTenRecent();
            return Ok(posts);
        }

        // Create: Creates a signle post
        [HttpPost("")]  // api/posts/id
        public IActionResult CreatePost([FromHeader] string username, [FromBody] PostDTO postDto)
        {
            try
            {
                PostResponseDTO result = postService.CreatePost(username, postDto.Title, postDto.Content);
                return Ok(result);
            }
            catch (NameDuplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update: Updates a single post
        [HttpPut("id")] // api/posts/id
        public IActionResult UpdatePost(string id, [FromHeader] string username, [FromBody] PostDTO postDto)
        {
            try
            {
                PostResponseDTO result = postService.Update(new Guid(id), username, postDto);
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Delete: Deletes a single post
        [HttpDelete("id")] // api/posts/id
        public IActionResult DeletePost(string id, [FromHeader] string username)
        {
            try
            {
                postService.Delete(username, new Guid(id));
                return Ok($"Post with id:[{id}] deleted successfully.");
            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
