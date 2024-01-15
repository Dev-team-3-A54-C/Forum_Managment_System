using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagmentSystem.Web.Controllers
{
	public class PostsController : Controller
	{
        private readonly IMapper mapper;
        private readonly IPostService postService;

        public PostsController(IMapper mapper, IPostService postService)
        {
            this.mapper = mapper;
            this.postService = postService;
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
            var viewModel = postService.Get(title);

            return View(viewModel);
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
    }
}
