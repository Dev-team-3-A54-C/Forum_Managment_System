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

        public IActionResult Index()
		{
			return View();
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

            string username = User.Identity.Name;

            postService.CreatePost(username, postViewModel.Title, postViewModel.Content);

            return RedirectToAction("Login", "Users");
        }
    }
}
