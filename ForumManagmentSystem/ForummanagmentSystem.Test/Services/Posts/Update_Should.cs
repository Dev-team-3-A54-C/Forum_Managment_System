using ForumManagmentSystem.Core.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForummanagmentSystem.Test.Services.Posts
{
	[TestClass]
	public class Update_Should
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
		public void SuccessfullyUpdatePost_AdminUser()
		{
			// Arrange
			var postId = Guid.NewGuid();
			var username = "AdminUser";
			var newData = new PostDTO { Title = "UpdatedTitle", Content = "UpdatedContent" };

			var adminUser = new UserDb { Id = Guid.NewGuid(), Username = username, IsAdmin = true };
			var existingPostDb = new PostDb 
			{ Id = postId, 
				Title = "OriginalTitle", 
				Content = "OriginalContent",
				User = adminUser 
			};

			usersRepositoryMock.Setup(repo => repo.GetByName(username)).Returns(adminUser);
			postsRepositoryMock.Setup(repo => repo.Update(postId, It.IsAny<PostDb>())).Returns(existingPostDb);
			autoMapperMock.Setup(mapper => mapper.Map<PostResponseDTO>(It.IsAny<PostDb>()))
				.Returns((PostDb postDb) => new PostResponseDTO 
				{ ID = postDb.Id.ToString(),
					Title = postDb.Title,
					Content = postDb.Content,
					CreatedOn = postDb.CreatedOn
				});

			// Act
			var result = postService.Update(postId, username, newData);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(postId.ToString(), result.ID);
			Assert.AreEqual(newData.Title, result.Title);
			Assert.AreEqual(newData.Content, result.Content);
		}

		[TestMethod]
		public void SuccessfullyUpdatePost_RegularUserOwnsPost()
		{
			// Arrange
			var postId = Guid.NewGuid();
			var username = "RegularUser";
			var newData = new PostDTO { Title = "UpdatedTitle", Content = "UpdatedContent" };

			var regularUser = new UserDb { Id = Guid.NewGuid(), Username = username, IsAdmin = false };
			var existingPostDb = new PostDb { 
				Id = postId, 
				Title = "OriginalTitle", 
				Content = "OriginalContent", 
				User = regularUser 
			};

			usersRepositoryMock.Setup(repo => repo.GetByName(username))
				.Returns(regularUser);
			postsRepositoryMock.Setup(repo => repo.Update(postId, It.IsAny<PostDb>()))
				.Returns(existingPostDb);
			autoMapperMock.Setup(mapper => mapper.Map<PostResponseDTO>(It.IsAny<PostDb>()))
				.Returns((PostDb postDb) => new PostResponseDTO { 
					ID = postDb.Id.ToString(), 
					Title = postDb.Title,
					Content = postDb.Content, 
					CreatedOn = postDb.CreatedOn 
				});

			// Act
			var result = postService.Update(postId, username, newData);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(postId.ToString(), result.ID);
			Assert.AreEqual(newData.Title, result.Title);
			Assert.AreEqual(newData.Content, result.Content);
		}

		[TestMethod]
		public void ThrowUnauthorizedOperationException_RegularUserDoesNotOwnPost()
		{
			// Arrange
			var postId = Guid.NewGuid();
			var username = "RegularUser";
			var newData = new PostDTO { Title = "UpdatedTitle", Content = "UpdatedContent" };

			var regularUser = new UserDb { Id = Guid.NewGuid(), Username = username, IsAdmin = false };
			var existingPostDb = new PostDb { 
				Id = postId, 
				Title = "OriginalTitle", 
				Content = "OriginalContent", 
				User = new UserDb 
				{ 
					Id = Guid.NewGuid(), 
					Username = "AnotherUser"
				} 
			};

			usersRepositoryMock.Setup(repo => repo.GetByName(username)).Returns(regularUser);
			postsRepositoryMock.Setup(repo => repo.Update(postId, It.IsAny<PostDb>()))
				.Returns(existingPostDb);

			// Act & Assert
			Assert.ThrowsException<UnauthorizedOperationException>(
				() => postService.Update(postId, username, newData));
		}
	}
}
