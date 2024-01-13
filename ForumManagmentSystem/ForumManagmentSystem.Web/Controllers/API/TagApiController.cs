using ForumManagmentSystem.Core.Helpers;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagmentSystem.Web.Controllers.API
{
    [Route("api/tags")]
    [ApiController]
    [Authorize]
    public class TagApiController : ControllerBase
    {
        private readonly ITagService tagService;
        private readonly AuthManager authManager;

        //TODO: catch AggregateException because Task<TagResponseDTO> throws Aggregate exception
        //when the TagService throws EntityNotFound. And when returning use:
        //return BadRequest/NotFound/...(ex.InnerException.Message())
        //!!! Create, Update and Delete actions should check if you are ADMIN!!!
        public TagApiController(ITagService tagService, AuthManager authManager)
        {
            this.tagService = tagService;
            this.authManager = authManager;
        }

        [HttpGet]
        public IActionResult GetAllTags()
        {
            try
            {
                var tags = tagService.GetAll();

                return Ok(tags);
            }
            catch(AggregateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetTag(string id)
        {
            try
            {
                var tag = tagService.GetById(new Guid(id));

                return Ok(tag);
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AggregateException ex)
            {
                return NotFound(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("")]
        public IActionResult CreateTag([FromBody] TagDTO tagDTO)
        {
            try
            {
                var newTag = tagService.Create(tagDTO);

                return Ok(newTag);
            }
            catch (NameDuplicationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (AggregateException ex)
            {
                return Conflict(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTag(string id, [FromBody] TagDTO tagDTO)
        {
            try
            {
                var newTag = tagService.Update(new Guid(id),tagDTO);

                return Ok(newTag);
            }
            catch (NameDuplicationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (AggregateException ex)
            {
                return Conflict(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTagWithTitle(string title)
        {
            try
            {
                var deletedTag = tagService.Delete(title);

                return Ok(deletedTag);
            }
            catch(EntityNotFoundException ex)
            {
                return Conflict(ex.Message);
            }
            catch(UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (AggregateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTagWithId(string id)
        {
            try
            {
                var deletedTag = tagService.Delete(new Guid(id));

                return Ok(deletedTag);
            }
            catch (EntityNotFoundException ex)
            {
                return Conflict(ex.Message);
            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (AggregateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
