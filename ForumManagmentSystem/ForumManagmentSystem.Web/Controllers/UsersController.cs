using AutoMapper;
using ForumManagmentSystem.Core.Helpers;
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
            var user = userService.GetDbUser("admin");
            //user.

            var loginViewModel = new LoginViewModel();

            return View(loginViewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginviewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginviewModel);
            }

            try
            {
                var user = authManager.TryGetUser(loginviewModel.Username, loginviewModel.Password);
                HttpContext.Session.SetString("user", user.Username);
                HttpContext.Session.SetString("id", user.Id.ToString());


                // TODO
                //HttpContext.Session.SetString("", user.Id.ToString());

                return RedirectToAction("Index", "Posts");
            }
            catch (UnauthorizedOperationException ex)
            {
                ModelState.AddModelError("Username", ex.Message);
                ModelState.AddModelError("Password", ex.Message);

                return View(loginviewModel);
            }
            catch(WrongPasswordException ex)
            {
                ModelState.AddModelError("Username", ex.Message);
                ModelState.AddModelError("Password", ex.Message);
                return View(loginviewModel);
            }
        }

        [HttpGet]
        [IsAuthenticatedAttribute]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            HttpContext.Session.Remove("id");

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

        [HttpGet]
        [IsAuthenticatedAttribute]
        public IActionResult Edit() // Update profile information
        {
            string currentUser = HttpContext.Session.GetString("user");
            var user = userService.GetUser(currentUser);
            ViewBag.currentUser = userService.GetDbUser(currentUser);

            var viewModel = new EditProfileViewModel();
            viewModel.Username = user.Username;
            viewModel.FirstName = user.FirstName;
            viewModel.LastName = user.LastName;
            viewModel.Email = user.Email;
            viewModel.PhoneNumber = user.PhoneNumber;

            return View(viewModel);
        }

        [HttpPost]
        [IsAuthenticatedAttribute]
        public IActionResult Edit(EditProfileViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var userId = HttpContext.Session.GetString("id");

            var userDTO = mapper.Map<EditUserDTO>(viewModel);
            _ = userService.Update(new Guid(userId), userDTO);

            return RedirectToAction("Index", "Posts");
        }

        [HttpPost]
        [IsAuthenticatedAttribute]
        public IActionResult BlockUser(string userToDelete)
        {
            var username = HttpContext.Session.GetString("user");
            var user = userService.GetDbUser(userToDelete);
            userService.Block(user.Id);
            return RedirectToAction("Index", "Posts");
        }
    }
}
