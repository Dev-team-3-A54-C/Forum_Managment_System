
namespace ForummanagmentSystem.Test.Services.Replies
{
    [TestClass]
    public class GetRepliesFromPost_Should
    {
        [TestMethod]
        public void Returns_ReplyResponseDTOs()
        {
            // Arrange
            var postTitle = "testPost";
            var repliesFromPost = new List<ReplyDb>
            {
                TestHelper.CreateReplyDb(),
                TestHelper.CreateReplyDb(),
                TestHelper.CreateReplyDb()
            };

            var mockReplyRepository = new Mock<IReplyRepository>();
            var mockUserRepository = new Mock<IUsersRepository>();
            var mockPostsRepository = new Mock<IPostsRepository>();
            var mockMapper = new Mock<IMapper>();

            // Set up mock responses for PostExists and GetRepliesFromPost methods
            mockPostsRepository.Setup(repo => repo.PostExists(postTitle)).Returns(true);
            mockReplyRepository.Setup(repo => repo.GetRepliesFromPost(postTitle)).ReturnsAsync(repliesFromPost);
            mockMapper.Setup(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>())).Returns((ReplyDb r) => new ReplyResponseDTO { Content = r.Content }); // Adjust the mapping as per your actual mapping logic

            var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

            // Act
            var result = replyService.GetRepliesFromPost(postTitle);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<ReplyResponseDTO>));
            Assert.AreEqual(repliesFromPost.Count, result.Count());

            // Verify that the repository methods were called
            mockPostsRepository.Verify(repo => repo.PostExists(postTitle), Times.Once);
            mockReplyRepository.Verify(repo => repo.GetRepliesFromPost(postTitle), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>()), Times.Exactly(repliesFromPost.Count));
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void GetRepliesFromPost_Throws_EntityNotFoundException_WhenPostDoesNotExist()
        {
            // Arrange
            var nonExistentPostTitle = "nonExistentPost";
            var mockReplyRepository = new Mock<IReplyRepository>();
            var mockUserRepository = new Mock<IUsersRepository>();
            var mockPostsRepository = new Mock<IPostsRepository>();
            var mockMapper = new Mock<IMapper>();

            // Set up mock response for PostExists method
            mockPostsRepository.Setup(repo => repo.PostExists(nonExistentPostTitle)).Returns(false);

            var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

            // Act
            replyService.GetRepliesFromPost(nonExistentPostTitle);

            // Assert
            // Expecting an EntityNotFoundException to be thrown
        }
    }
}
