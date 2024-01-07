using ForumManagmentSystem.Core.RequestDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagmentSystem.Web.Controllers
{
    [Route("api/replies")]
    [ApiController]
    public class ReplyApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetReplies()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        public IActionResult GetReply(Guid id)
        {
            throw new NotImplementedException();
        }
        [HttpPost("")] 
        public IActionResult CreateReply([FromBody] ReplyDTO replyDTO)
        {
            throw new NotImplementedException();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateReply(Guid id, [FromBody] ReplyDTO replyDTO)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteReply(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
