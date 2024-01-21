using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForummanagmentSystem.Test.Services.Posts
{
	[TestClass]
	public class GetAllLikedByUser_Should
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
		public void GetAllLikedByUser_ValidUser_ReturnsPostResponseDTOList()
		{
			// Arrange
			var username = "TestUser";

			var userDb = new UserDb { Id = Guid.NewGuid(), Username = username };
			var postLikesDbList = new List<PostLikesDb>
			{
				new PostLikesDb { PostId = Guid.NewGuid(), UserId = userDb.Id , Post = TestHelper.CreatePostDb()},
				new PostLikesDb { PostId = Guid.NewGuid(), UserId = userDb.Id , Post = TestHelper.CreatePostDb()},
				new PostLikesDb { PostId = Guid.NewGuid(), UserId = userDb.Id , Post = TestHelper.CreatePostDb()}
			};

			usersRepositoryMock.Setup(repo => repo.GetByName(username)).Returns(userDb);
			postsRepositoryMock.Setup(repo => repo.GetAllLikedByUser(username)).Returns(postLikesDbList.AsQueryable());
			autoMapperMock.Setup(mapper => mapper.Map<PostResponseDTO>(It.IsAny<PostLikesDb>()))
				.Returns((PostLikesDb postLikesDb) => new PostResponseDTO 
				{ 
					ID = postLikesDb.Post.Id.ToString()
				});

			// Act
			var result = postService.GetAllLikedByUser(username);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(postLikesDbList.Count, result.Count());
		}
		[TestMethod]
		public void GetAllLikedByUser_UserWithNoLikedPosts_ReturnsEmptyList()
		{
			// Arrange
			var username = "TestUser";

			var userDb = new UserDb { Id = Guid.NewGuid(), Username = username };
			usersRepositoryMock.Setup(repo => repo.GetByName(username)).Returns(userDb);
			postsRepositoryMock.Setup(repo => repo.GetAllLikedByUser(username))
				.Returns(new List<PostLikesDb>().AsQueryable());

			// Act
			var result = postService.GetAllLikedByUser(username);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(0, result.Count());
		}
	}
}
