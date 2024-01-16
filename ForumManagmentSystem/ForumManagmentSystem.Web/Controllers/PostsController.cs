using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Core.ViewModels;
using ForumManagmentSystem.Infrastructure.Exceptions;
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
        public IActionResult Index()
        {
            var viewModel = postService.GetAll();

            return View(viewModel);
        }

        [HttpGet("Posts/Detail/{title}")]
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
		public IActionResult Create()
		{
            var viewModel = new PostViewModel();

            return View(viewModel);
		}

        [HttpPost]
        public IActionResult Create(PostViewModel postViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(postViewModel);
            }

            string username = HttpContext.Session.GetString("user");

            var post = mapper.Map<PostDTO>(postViewModel);

            postService.CreatePost(username, post);

            return RedirectToAction("Index", "Posts");
        }

        [HttpPost]
        public IActionResult Reply(ReplyDTO reply)
        {
            string username = HttpContext.Session.GetString("user");
            reply.CreatedBy = username;

            replyService.Create(reply);
            return RedirectToAction("Detail", "Posts");
        }
    }
}
