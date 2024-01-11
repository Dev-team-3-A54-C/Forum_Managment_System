using AutoMapper;
using ForumManagmentSystem.Core.Helpers;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Core.ViewModels;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ForumManagmentSystem.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly AuthManager authManager;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UsersController(IUserService userService, AuthManager authManager, IMapper mapper)
        {
            this.userService = userService;
            this.authManager = authManager;
            this.mapper = mapper;
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

            var userDTO = mapper.Map<UserDTO>(viewModel);
            _ = userService.CreateUser(userDTO);

            return RedirectToAction("Login", "Users");
        }
    }
}
