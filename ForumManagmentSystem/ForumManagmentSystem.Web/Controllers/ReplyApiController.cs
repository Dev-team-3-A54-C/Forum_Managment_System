using ForumManagmentSystem.Core.Helpers;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagmentSystem.Web.Controllers
{
    [Route("api/replies")]
    [ApiController]
    public class ReplyApiController : ControllerBase
    {
        private readonly IReplyService replyService;
        private readonly AuthManager authManager;

        //TODO: catch AggregateException because Task<ReplyResponseDTO> throws Aggregate exception
        //when the TagService throws EntityNotFound. And when returning use:
        //return BadRequest/NotFound/...(ex.InnerException.Message())
        public ReplyApiController(IReplyService replyService, AuthManager authManager)
        {
            this.replyService = replyService;
            this.authManager = authManager;
        }
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
