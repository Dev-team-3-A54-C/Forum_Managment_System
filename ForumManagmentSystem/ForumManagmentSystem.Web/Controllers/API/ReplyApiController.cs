using ForumManagmentSystem.Core.Helpers;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagmentSystem.Web.Controllers.API
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
            try
            {
                var replies = replyService.GetAll();

                return Ok(replies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetReply(string id)
        {
            try
            {
                var reply = replyService.Get(new Guid(id));

                return Ok(reply);
            }
            catch (EntityNotFoundException ex) 
            {
                return NotFound(ex.Message);
            }
            catch(AggregateException ex)
            {
                return NotFound(ex.InnerException.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
