using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForummanagmentSystem.Test.Services.Posts
{
	[TestClass]
	public class Delete_Should
	{
		private Mock<IUsersRepository> usersRepositoryMock;
		private Mock<IPostsRepository> postsRepositoryMock;
		private Mock<IMapper> autoMapperMock;
		private PostService postService;

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
		public void Delete_ValidAdminUser_ReturnsPostResponseDTO()
		{
			// Arrange
			var username = "AdminUser";
			var postId = Guid.NewGuid();

			var userDb = new UserDb { Id = Guid.NewGuid(), Username = username, IsAdmin = true };
			var postDb = new PostDb { Id = postId };

			usersRepositoryMock.Setup(repo => repo.GetByName(username)).Returns(userDb);
			postsRepositoryMock.Setup(repo => repo.GetById(postId)).Returns(postDb);
			postsRepositoryMock.Setup(repo => repo.Delete(postId)).Returns(postDb);

			autoMapperMock.Setup(mapper => mapper.Map<PostResponseDTO>(It.IsAny<PostDb>()))
				.Returns(new PostResponseDTO { ID = postDb.Id.ToString() });

			// Act
			var result = postService.Delete(username, postId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(postDb.Id.ToString(), result.ID);
		}

		[TestMethod]
		public void Delete_ValidRegularUserOwnPost_ReturnsPostResponseDTO()
		{
			// Arrange
			var username = "RegularUser";
			var postId = Guid.NewGuid();

			var userDb = new UserDb { Id = Guid.NewGuid(), Username = username, IsAdmin = false };
			var postDb = new PostDb { Id = postId, User = userDb };
			userDb.MyPosts.Add(postDb);

			usersRepositoryMock.Setup(repo => repo.GetByName(username)).Returns(userDb);
			postsRepositoryMock.Setup(repo => repo.GetById(postId)).Returns(postDb);
			postsRepositoryMock.Setup(repo => repo.Delete(postId)).Returns(postDb);


			autoMapperMock.Setup(mapper => mapper.Map<PostResponseDTO>(It.IsAny<PostDb>()))
				.Returns(new PostResponseDTO { ID = postDb.Id.ToString() });

			// Act
			var result = postService.Delete(username, postId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(postDb.Id.ToString(), result.ID);
		}

		[TestMethod]
		public void Delete_NonAdminUserNotOwnPost_ThrowsUnauthorizedOperationException()
		{
			// Arrange
			var username = "RegularUser";
			var postId = Guid.NewGuid();

			var userDb = new UserDb { Id = Guid.NewGuid(), Username = username, IsAdmin = false };
			var postDb = new PostDb 
			{ Id = postId, User = new UserDb { Id = Guid.NewGuid(), Username = "AnotherUser" } };

			usersRepositoryMock.Setup(repo => repo.GetByName(username)).Returns(userDb);
			postsRepositoryMock.Setup(repo => repo.GetById(postId)).Returns(postDb);

			// Act & Assert
			Assert.ThrowsException<UnauthorizedOperationException>(
				() => postService.Delete(username, postId));
		}
	}
}
