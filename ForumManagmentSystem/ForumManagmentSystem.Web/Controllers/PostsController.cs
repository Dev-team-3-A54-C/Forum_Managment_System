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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ForumManagmentSystem.Web.Controllers
{
    public class PostsController : Controller
	{
        private readonly IMapper mapper;
        private readonly IPostService postService;
        private readonly IReplyService replyService;
        private readonly IUserService userService;

        public PostsController(IMapper mapper, IPostService postService, IReplyService replyService, IUserService userService)
        {
            this.mapper = mapper;
            this.postService = postService;
            this.replyService = replyService;
            this.userService = userService;
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
            string currentUser = HttpContext.Session.GetString("user");
            ViewBag.currentUser = userService.GetDbUser(currentUser);
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

                string currentUser = HttpContext.Session.GetString("user");
                ViewBag.currentUser = userService.GetDbUser(currentUser);

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
            string username = HttpContext.Session.GetString("user");

            var postID = postService.Get(viewModel.Post.Title).ID;

            var postDTO = new PostResponseDTO();
            postDTO.Title = viewModel.Post.Title;
            postDTO.Content = viewModel.Post.Content;

            var post = mapper.Map<PostDTO>(postDTO);

            postService.Update(new Guid(postID),username, post);

            return RedirectToAction("Detail", "Posts", new { title = post.Title });
        }

        [HttpGet("Posts/Reply/Edit/{id}")]
        [IsAuthenticatedAttribute]
        public IActionResult EditReply([FromRoute] string id)
        {
            try
            {
                var replyResponseDTO = replyService.Get(new Guid(id));
                var replyDTO = mapper.Map<ReplyDTO>(replyResponseDTO);

                var post = postService.Get(replyDTO.PostTitle);

                var viewModel = new PostDetailViewModel();
                viewModel.Reply = replyDTO;
                viewModel.Post = post;

                return View(viewModel);
            }
            catch(EntityNotFoundException)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [IsAuthenticatedAttribute]
        public IActionResult EditReply(int TODO)
        {
            throw new NotImplementedException();
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
            var userId = HttpContext.Session.GetString("id");
            //var replyDTO = new AddReplyLikeDTO();
            //replyDTO.ReplyId = replyID;
            //replyDTO.Username = username;

            replyService.AddLike(new Guid(userId), new Guid(replyID));

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
