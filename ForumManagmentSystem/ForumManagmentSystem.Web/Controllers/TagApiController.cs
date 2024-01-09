using ForumManagmentSystem.Core.Helpers;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagmentSystem.Web.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagApiController : ControllerBase
    {
        private readonly ITagService tagService;
        private readonly AuthManager authManager;

        //TODO: catch AggregateException because Task<TagResponseDTO> throws Aggregate exception
        //when the TagService throws EntityNotFound. And when returning use:
        //return BadRequest/NotFound/...(ex.InnerException.Message())
        public TagApiController(ITagService tagService, AuthManager authManager)
        {
            this.tagService = tagService;
            this.authManager = authManager;
        }

        [HttpGet]
        public IActionResult GetTags()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        public IActionResult GetTag(string id)
        {
            throw new NotImplementedException();
        }
        [HttpPost("")]
        public IActionResult CreateTag([FromBody] TagDTO tagDTO)
        {
            throw new NotImplementedException();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTag(string id, [FromBody] TagDTO tagDTO)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTag(string id)
        {
            throw new NotImplementedException();
        }
    }
}
