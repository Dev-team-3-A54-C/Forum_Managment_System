using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForummanagmentSystem.Test.Services.Posts
{
	[TestClass]
	public class GetByTitle_Should
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
		public void Get_ExistingPost_ReturnsPostResponseDTO()
		{
			// Arrange
			var postTitle = "TestPost";
			var postDb = new PostDb { Id = Guid.NewGuid(), Title = postTitle, Content = "Lorem ipsum", CreatedOn = DateTime.Now, User = new UserDb() };

			postsRepositoryMock.Setup(repo => repo.GetByTitle(postTitle)).Returns(postDb);
			autoMapperMock.Setup(mapper => mapper.Map<PostResponseDTO>(It.IsAny<PostDb>()))
				.Returns((PostDb post) => new PostResponseDTO { ID = post.Id.ToString(), Title = post.Title, Content = post.Content, CreatedOn = post.CreatedOn });

			// Act
			var result = postService.Get(postTitle);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(postDb.Id.ToString(), result.ID);
		}

		[TestMethod]
		public void Get_NonExistingPost_ReturnsNull()
		{
			// Arrange
			var postTitle = "NonExistingPost";

			postsRepositoryMock.Setup(repo => repo.GetByTitle(postTitle)).Returns((PostDb)null);

			// Act
			var result = postService.Get(postTitle);

			// Assert
			Assert.IsNull(result);
		}
	}
}
