using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Web.Exceptions;
using ForumManagmentSystem.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("")] // api/users/
        public IActionResult GetPosts()
        {
            var posts = postService.GetAll();
            return Ok(posts);
        }

        [HttpGet("{id}")] // api/users/{id}
        public IActionResult GetPost(int id)
        {
            try
            {
                PostDb post = postService.Get(id);
                PostResponseDTO postResponseDTO = modelMapper.Map(post);
                // TODO: Resposne DTO           BeerResponseDto beerResponseDto = modelMapper.Map(beer);

                return Ok(post);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
