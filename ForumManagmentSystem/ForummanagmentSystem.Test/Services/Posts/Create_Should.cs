
using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using Moq;

namespace ForummanagmentSystem.Test.Services.Posts
{
    [TestClass]
    public class Create_Should
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
		public void CreatePost_ValidData_ReturnsPostResponseDTO()
		{
			// Arrange
			var username = "TestUser";
			var postDto = new PostDTO { Title = "NewPost", Content = "Lorem ipsum" };

			usersRepositoryMock.Setup(repo => repo.GetByName(username))
				.Returns(new UserDb { Id = Guid.NewGuid(), Username = username });
			postsRepositoryMock.Setup(repo => repo.PostExists(postDto.Title))
				.Returns(false);

			var createdPostDb = new PostDb
			{
				Id = Guid.NewGuid(),
				Title = postDto.Title,
				Content = postDto.Content,
				User = new UserDb(),
				CreatedOn = DateTime.Now
			};

			postsRepositoryMock.Setup(repo => repo.Create(It.IsAny<PostDb>()))
				.Returns(createdPostDb);

			autoMapperMock.Setup(mapper => mapper.Map<PostResponseDTO>(It.IsAny<PostDb>()))
				.Returns(new PostResponseDTO
				{
					ID = createdPostDb.Id.ToString(),
					Title = createdPostDb.Title,
					Content = createdPostDb.Content
				});

			// Act
			var result = postService.CreatePost(username, postDto);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(createdPostDb.Id.ToString(), result.ID);
			Assert.AreEqual(createdPostDb.Title, result.Title);
			Assert.AreEqual(createdPostDb.Content, result.Content);
		}

		[TestMethod]
		public void CreatePost_DuplicatePostTitle_ThrowsNameDuplicationException()
		{
			// Arrange
			var username = "TestUser";
			var postDto = new PostDTO { Title = "ExistingPost", Content = "Lorem ipsum" };

			usersRepositoryMock.Setup(repo => repo.GetByName(username))
				.Returns(new UserDb { Id = Guid.NewGuid(), Username = username });
			postsRepositoryMock.Setup(repo => repo.PostExists(postDto.Title))
				.Returns(true);

			// Act & Assert
			Assert.ThrowsException<NameDuplicationException>(
				() => postService.CreatePost(username, postDto));
		}

	}
}
