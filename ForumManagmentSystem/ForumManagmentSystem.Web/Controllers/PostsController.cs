using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Core.ViewModels;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagmentSystem.Web.Controllers
{
    public class PostsController : Controller
	{
        private readonly IMapper mapper;
        private readonly IPostService postService;
        private readonly IReplyService replyService;

        public PostsController(IMapper mapper, IPostService postService, IReplyService replyService)
        {
            this.mapper = mapper;
            this.postService = postService;
            this.replyService = replyService;
        }

		[HttpGet]
        [IsAuthenticatedAttribute]
        public IActionResult Index()
        {
            var viewModel = postService.GetAll();
            return View(viewModel);
        }

        [HttpGet("Posts/Users/{createdBy}")]
        public IActionResult Overview([FromRoute] string createdBy)
        {
            var posts = postService.GetAllFromUser(createdBy);
            return View(posts);
        }

        [HttpGet("Posts/Detail/{title}")]
        [IsAuthenticatedAttribute]
        public IActionResult Detail([FromRoute] string title)
        {
            try
            {
				var postResponse = postService.Get(title);
                var viewModel = new PostDetailViewModel();
                viewModel.Post = postResponse;

                return View(viewModel);
			}catch(EntityNotFoundException)
            {
                return View("Error");
            }
		}

		[HttpGet]
        [IsAuthenticatedAttribute]
        public IActionResult Create()
		{
            var viewModel = new CreatePostViewModel();

            return View(viewModel);
		}

        [HttpPost]
        [IsAuthenticatedAttribute]
        public IActionResult Create(CreatePostViewModel createPostViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createPostViewModel);
            }

            string username = HttpContext.Session.GetString("user");

            var post = mapper.Map<PostDTO>(createPostViewModel);

            postService.CreatePost(username, post);

            return RedirectToAction("Index", "Posts");
        }

        [HttpGet("Posts/Edit/{title}")]
        [IsAuthenticatedAttribute]
        public IActionResult Edit([FromRoute] string title)
        {
            try
            {
                var postResponse = postService.Get(title);
                var viewModel = new PostDetailViewModel();
                viewModel.Post = postResponse;

                return View(viewModel);
            }
            catch (EntityNotFoundException)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [IsAuthenticatedAttribute]
        public IActionResult Edit(PostDetailViewModel viewModel)
        {
            return View(viewModel);
        }

        [HttpPost]
        [IsAuthenticatedAttribute]
        public IActionResult Reply(ReplyDTO reply)
        {
            string username = HttpContext.Session.GetString("user");
            reply.CreatedBy = username;

            replyService.Create(reply);
            return RedirectToAction("Detail", "Posts", new { title = reply.PostTitle });
        }

        [HttpPost]
        public IActionResult AddLiketoPost(string postID)
        {
            var userID = HttpContext.Session.GetString("id");
            postService.AddLike(new Guid(userID), new Guid(postID));

            var post = postService.Get(new Guid(postID));

            return RedirectToAction("Detail", "Posts", new { post.Title });
        }

        [HttpPost]
        public IActionResult AddLiketoReply(string replyID)
        {
            var username = HttpContext.Session.GetString("user");
            var replyDTO = new AddReplyLikeDTO();
            replyDTO.ReplyId = replyID;
            replyDTO.Username = username;

            var userID = HttpContext.Session.GetString("id");

            replyService.AddLike(new Guid(userID),new Guid(replyID));

            //var post = postService.Get();

            //return RedirectToAction("Detail", "Posts", new { post.Title });
            return RedirectToAction("Detail", "Posts");
        }

        [HttpGet("Posts/Delete/{postID}")]
        public IActionResult Delete([FromRoute] string postID)
        {
            var username = HttpContext.Session.GetString("user");
            postService.Delete(username, new Guid(postID));
            return RedirectToAction("Index", "Posts");
        }
    }
}
