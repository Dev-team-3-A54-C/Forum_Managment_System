using ForumManagmentSystem.Core.Helpers;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Data.Models.ViewModel;
using ForumManagmentSystem.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ForumManagmentSystem.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly AuthManager authManager;
        private readonly IUserService userService;

        public UsersController(IUserService userService, AuthManager authManager)
        {
            this.userService = userService;
            this.authManager = authManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var viewModel = new LoginViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                authManager.Login(viewModel.Username, viewModel.Password);

                return RedirectToAction("Index", "Home");
            }
            catch (UnauthorizedOperationException ex)
            {
                ModelState.AddModelError("Username", ex.Message);
                ModelState.AddModelError("Password", ex.Message);

                return View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            authManager.Logout();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            var viewModel = new RegisterViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (viewModel.Password != viewModel.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");

                return View(viewModel);
            }

            UserDTO user = new UserDTO()
            {
                Username = viewModel.Username,
                Password = viewModel.Password,
                Email = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName
            };
            _ = userService.CreateUser(user);

            return RedirectToAction("Login", "Users");
        }
    }
}
