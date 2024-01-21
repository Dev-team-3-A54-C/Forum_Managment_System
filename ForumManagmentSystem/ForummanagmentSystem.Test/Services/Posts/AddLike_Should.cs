using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForummanagmentSystem.Test.Services.Posts
{
	[TestClass]
	public class AddLike_Should
	{
		private Mock<IUsersRepository> usersRepositoryMock;
		private Mock<IPostsRepository> postsRepositoryMock;
		private IPostService postService;
		private Mock<IMapper> autoMapperMock;

		[TestInitialize]
		public void Initialize()
		{
			usersRepositoryMock = new Mock<IUsersRepository>();
			postsRepositoryMock = new Mock<IPostsRepository>();
			autoMapperMock = new Mock<IMapper>();
			postService = new PostService
				(postsRepositoryMock.Object, usersRepositoryMock.Object, autoMapperMock.Object);
		}

		[TestMethod]
		public void AddLike_UserAndPostExist_AddsLikeAndReturnsTrue()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var postId = Guid.NewGuid();

			var userDb = new UserDb { Id = userId, LikedPosts = new List<PostLikesDb>() };
			var postDb = new PostDb { Id = postId, LikesCount = 0 };

			usersRepositoryMock.Setup(repo => repo.GetById(userId)).Returns(userDb);
			postsRepositoryMock.Setup(repo => repo.GetById(postId)).Returns(postDb);
			postsRepositoryMock.Setup(repo => repo.AddLike(It.IsAny<PostLikesDb>())).Returns(true);

			// Act
			var result = postService.AddLike(userId, postId);

			// Assert
			Assert.IsTrue(result);
			Assert.AreEqual(1, postDb.LikesCount);
		}

		[TestMethod]
		public void AddLike_UserAlreadyLikedPost_RemovesLikeAndReturnsTrue()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var postId = Guid.NewGuid();

			var userDb = new UserDb { Id = userId, LikedPosts = new List<PostLikesDb> { new PostLikesDb { UserId = userId, PostId = postId } } };
			var postDb = new PostDb { Id = postId, LikesCount = 1 };

			usersRepositoryMock.Setup(repo => repo.GetById(userId)).Returns(userDb);
			postsRepositoryMock.Setup(repo => repo.GetById(postId)).Returns(postDb);
			postsRepositoryMock.Setup(repo => repo.RemoveLike(It.IsAny<PostLikesDb>())).Returns(true);

			// Act
			var result = postService.AddLike(userId, postId);

			// Assert
			Assert.IsTrue(result);
			Assert.AreEqual(0, postDb.LikesCount);
		}

		[TestMethod]
		public void AddLike_UserAndPostNotExist_ReturnsFalse()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var postId = Guid.NewGuid();

			var userDb = new UserDb { Id = userId, LikedPosts = 
				new List<PostLikesDb> { new PostLikesDb { UserId = userId, PostId = postId } } };
			var postDb = new PostDb { Id = postId, LikesCount = 1 };

			usersRepositoryMock.Setup(repo => repo.GetById(userId)).Returns(userDb);
			postsRepositoryMock.Setup(repo => repo.GetById(postId)).Returns(postDb);
			postsRepositoryMock.Setup(repo => repo.RemoveLike(It.IsAny<PostLikesDb>())).Returns(false);

			// Act
			var result = postService.AddLike(userId, postId);

			// Assert
			Assert.IsFalse(result);
		}
	}
}
