using ForumManagmentSystem.Core.RequestDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagmentSystem.Web.Controllers
{
    [Route("api/replies")]
    [ApiController]
    public class ReplyApiController : ControllerBase
    {
        //TODO: catch AggregateException because Task<ReplyResponseDTO> throws Aggregate exception
        //when the TagService throws EntityNotFound. And when returning use:
        //return BadRequest/NotFound/...(ex.InnerException.Message())
        [HttpGet]
        public IActionResult GetReplies()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        public IActionResult GetReply(string id)
        {
            throw new NotImplementedException();
        }
        [HttpPost("")] 
        public IActionResult CreateReply([FromBody] ReplyDTO replyDTO)
        {
            throw new NotImplementedException();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateReply(string id, [FromBody] ReplyDTO replyDTO)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteReply(string id)
        {
            throw new NotImplementedException();
        }

    }
}
