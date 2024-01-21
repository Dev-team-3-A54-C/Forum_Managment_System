
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
		Mock<IUsersRepository> usersRepositoryMock;
		Mock<IPostsRepository> postRepositoryMock;
		Mock<IMapper> mapper;

		[TestInitialize]
		public void Init()
		{
			usersRepositoryMock = new Mock<IUsersRepository>();
			postRepositoryMock = new Mock<IPostsRepository>();
			mapper = new Mock<IMapper>();
		}
		[TestMethod]
		public void Throw_NameDuplicationException_When_Name_Exists()
        {
			var postsService = new PostService(postRepositoryMock.Object, usersRepositoryMock.Object, mapper.Object);

			var existingPostTitle = "Existing Post";
			postRepositoryMock.Setup(repo => repo.PostExists(existingPostTitle)).Returns(true);

			var author = "Johnny";

			// Act and Assert
			Assert.ThrowsException<NameDuplicationException>(() =>
				postsService.CreatePost(author, new PostDTO() { Title = existingPostTitle, Content = "Test content." }));
		}
        [TestMethod]
		public void Throw_EntityNotFoundException_When_User_Does_Not_Exist()
        {
			//Arrange
			var postsService = new PostService(postRepositoryMock.Object, usersRepositoryMock.Object, mapper.Object);

			var author = "John Doe";
			postRepositoryMock.Setup(repo => repo.PostExists(It.IsAny<string>())).Returns(false);
			// Act and Assert
			Assert.ThrowsException<EntityNotFoundException>(() =>
				postsService.CreatePost(author, new PostDTO() { Title = "PostTitle", Content = "TestContent."}));
		}
        [TestMethod]
		public void Return_Created_Post()
        {
			// Arrange
			var postsService = new PostService(postRepositoryMock.Object, usersRepositoryMock.Object, mapper.Object);

			var author = new UserDb() { Username = "John Doe" };

			postRepositoryMock.Setup(repo => repo.PostExists(It.IsAny<string>())).Returns(false);
			usersRepositoryMock.Setup(repo => repo.GetByName(It.IsAny<string>())).Returns(author);

			// Act
			var result = postsService.CreatePost(author.Username, new PostDTO() { Title = "TestPost", Content = "Test content."});

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("New Post", result.Title);
			Assert.AreEqual("This is a test post.", result.Content);
			Assert.AreEqual(author.Username, result.CreatedBy);
		}

	}
}
