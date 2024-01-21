using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ForummanagmentSystem.Test.Services.Posts
{
	[TestClass]
	public class GetById_Should
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
			var postId = Guid.NewGuid();
			var postDb = new PostDb { Id = postId, Title = "TestPost", Content = "Lorem ipsum", CreatedOn = DateTime.Now, User = new UserDb() };

			postsRepositoryMock.Setup(repo => repo.GetById(postId)).Returns(postDb);
			autoMapperMock.Setup(mapper => mapper.Map<PostResponseDTO>(It.IsAny<PostDb>()))
				.Returns((PostDb post) => new PostResponseDTO 
				{ 
					ID = post.Id.ToString(),
					Title = post.Title,
					Content = post.Content,
					CreatedOn = post.CreatedOn 
				});

			// Act
			var result = postService.Get(postId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(postDb.Id.ToString(), result.ID);
		}

		[TestMethod]
		public void Get_NonExistingPost_ReturnsNull()
		{
			// Arrange
			var postId = Guid.NewGuid();

			postsRepositoryMock.Setup(repo => repo.GetById(postId)).Returns((PostDb)null);

			// Act
			var result = postService.Get(postId);

			// Assert
			Assert.IsNull(result);
		}
	}
}
