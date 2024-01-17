using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Core.ViewModels;
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
            /*
            string currentUsername = HttpContext.Session.GetString("user");

            if (createdBy == currentUsername)
            {
                var viewModel = postService.GetAllFromUser(currentUsername);
                return View(viewModel);
            }
            */

            var posts = postService.GetAllFromUser(createdBy);
            return View(posts);
        }

        [HttpGet]
        public IActionResult OwnPosts()
        {
            return View();
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

        [HttpPost]
        [IsAuthenticatedAttribute]
        public IActionResult Reply(ReplyDTO reply)
        {
            string username = HttpContext.Session.GetString("user");
            reply.CreatedBy = username;

            replyService.Create(reply);
            return RedirectToAction("Detail", "Posts");
        }
    }
}
