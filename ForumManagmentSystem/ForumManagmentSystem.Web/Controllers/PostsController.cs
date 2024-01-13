using Microsoft.AspNetCore.Mvc;

namespace ForumManagmentSystem.Web.Controllers
{
	public class PostsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Create()
		{
			return View();
		}
	}
}
