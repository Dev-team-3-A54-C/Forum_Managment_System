using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.RequestDTOs;

namespace ForumManagmentSystem.Web.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsApiController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly IModelMapper modelMapper;
        private readonly AuthManager authManager;

        public PostsApiController(IPostService postService, IModelMapper modelMapper, AuthManager authManager)
        {
            this.postService = postService;
            this.modelMapper = modelMapper;
            this.authManager = authManager;
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

        // Create: Creates a signle post
        [HttpPost("")]  // api/posts/id
        public IActionResult CreatePost([FromHeader] string username, [FromBody] PostDTO postDto)
        {
            throw new NotImplementedException();
        }

        // Update: Updates a single post
        [HttpPut("id")] // api/posts/id
        public IActionResult UpdatePost(string id, [FromHeader] string username, [FromBody] PostDTO postDto)
        {
            throw new NotImplementedException();
        }

        // Delete: Deletes a single post
        [HttpDelete("id")] // api/posts/id
        public IActionResult DeletePost(string id, [FromHeader] string username)
        {
            throw new NotImplementedException();
        }
    }
}
