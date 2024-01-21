using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForummanagmentSystem.Test.Services.Posts
{
	[TestClass]
	public class GetAllFromUser_Should
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
		public void GetAllFromUser_ValidUser_ReturnsPostResponseDTOList()
		{
			// Arrange
			var username = "TestUser";

			var userDb = new UserDb { Id = Guid.NewGuid(), Username = username };
			var postDbList = new List<PostDb>
		{
			new PostDb { Id = Guid.NewGuid(), Title = "Post1", Content = "Content1", CreatedOn = DateTime.Now, User = userDb },
			new PostDb { Id = Guid.NewGuid(), Title = "Post2", Content = "Content2", CreatedOn = DateTime.Now, User = userDb },
			new PostDb { Id = Guid.NewGuid(), Title = "Post3", Content = "Content3", CreatedOn = DateTime.Now, User = userDb }
		};

			usersRepositoryMock.Setup(repo => repo.GetByName(username)).Returns(userDb);
			postsRepositoryMock.Setup(repo => repo.GetAll()).Returns(postDbList.ToList());
			autoMapperMock.Setup(mapper => mapper.Map<PostResponseDTO>(It.IsAny<PostDb>()))
				.Returns((PostDb postDb) => new PostResponseDTO { 
					ID = postDb.Id.ToString(), 
					Title = postDb.Title, 
					Content = postDb.Content, 
					CreatedOn = postDb.CreatedOn });

			// Act
			var result = postService.GetAllFromUser(username);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(postDbList.Count, result.Count());
		}

		[TestMethod]
		public void GetAllFromUser_UserWithNoPosts_ReturnsEmptyList()
		{
			// Arrange
			var username = "TestUser";

			var userDb = new UserDb { Id = Guid.NewGuid(), Username = username };
			usersRepositoryMock.Setup(repo => repo.GetByName(username)).Returns(userDb);
			postsRepositoryMock.Setup(repo => repo.GetAll()).Returns(new List<PostDb>());

			// Act
			var result = postService.GetAllFromUser(username);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(0, result.Count());
		}
	}
}
