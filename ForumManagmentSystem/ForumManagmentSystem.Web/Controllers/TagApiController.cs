using ForumManagmentSystem.Core.RequestDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagmentSystem.Web.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTags()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        public IActionResult GetTag(Guid id)
        {
            throw new NotImplementedException();
        }
        [HttpPost("")]
        public IActionResult CreateTag([FromBody] TagDTO tagDTO)
        {
            throw new NotImplementedException();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTag(Guid id, [FromBody] TagDTO tagDTO)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTag(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
