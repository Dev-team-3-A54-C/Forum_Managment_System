using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForummanagmentSystem.Test.Services.Posts
{
	[TestClass]
	public class GetAll_Should
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
		public void GetAll_ReturnsPostResponseDTOList()
		{
			// Arrange
			var postDbList = new List<PostDb>
		{
			new PostDb { Id = Guid.NewGuid(), Title = "Post1", Content = "Content1", CreatedOn = DateTime.Now, User = new UserDb() },
			new PostDb { Id = Guid.NewGuid(), Title = "Post2", Content = "Content2", CreatedOn = DateTime.Now, User = new UserDb() },
			new PostDb { Id = Guid.NewGuid(), Title = "Post3", Content = "Content3", CreatedOn = DateTime.Now, User = new UserDb() }
		};

			postsRepositoryMock.Setup(repo => repo.GetAll()).Returns(postDbList.ToList());
			autoMapperMock.Setup(mapper => mapper.Map<PostResponseDTO>(It.IsAny<PostDb>()))
				.Returns((PostDb postDb) => new PostResponseDTO 
				{ 
					ID = postDb.Id.ToString(), 
					Title = postDb.Title, 
					Content = postDb.Content, 
					CreatedOn = postDb.CreatedOn });

			// Act
			var result = postService.GetAll();

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(postDbList.Count, result.Count());
		}

		[TestMethod]
		public void GetAll_NoPosts_ReturnsEmptyList()
		{
			// Arrange
			postsRepositoryMock.Setup(repo => repo.GetAll()).Returns(new List<PostDb>());

			// Act
			var result = postService.GetAll();

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(0, result.Count());
		}
	}
}
