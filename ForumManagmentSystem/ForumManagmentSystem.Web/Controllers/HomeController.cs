using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagmentSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IPostService postService;
        public HomeController(IUserService userService, IPostService postService)
        {
            this.userService = userService;
            this.postService = postService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.userCount = userService.GetCount();
            ViewBag.postCount = postService.GetCount();

			ViewBag.topCommented = postService.GetTopTenByComments();
			ViewBag.topRecent = postService.GetTopTenRecent();

            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
