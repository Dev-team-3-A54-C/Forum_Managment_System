
namespace ForummanagmentSystem.Test.Services.Replies
{
    [TestClass]
    public class GetRepliesMadeByUser_Should
    {
        [TestMethod]
        public void GetRepliesMadeByUser_Returns_ReplyResponseDTOs()
        {
            // Arrange
            var username = "testUser";
            var repliesFromUser = new List<ReplyDb>
            {
                TestHelper.CreateReplyDb(),
                TestHelper.CreateReplyDb(),
                TestHelper.CreateReplyDb()
            };

            var mockReplyRepository = new Mock<IReplyRepository>();
            var mockUserRepository = new Mock<IUsersRepository>();
            var mockPostsRepository = new Mock<IPostsRepository>();
            var mockMapper = new Mock<IMapper>();

            // Set up mock responses for UserExists and GetRepliesFromUser methods
            mockUserRepository.Setup(repo => repo.UserExists(username)).Returns(true);
            mockReplyRepository.Setup(repo => repo.GetRepliesFromUser(username)).ReturnsAsync(repliesFromUser);
            mockMapper.Setup(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>())).Returns((ReplyDb r) => new ReplyResponseDTO { Content = r.Content }); // Adjust the mapping as per your actual mapping logic

            var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

            // Act
            var result = replyService.GetRepliesMadeByUser(username);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<ReplyResponseDTO>));
            Assert.AreEqual(repliesFromUser.Count, result.Count());

            // Verify that the repository methods were called
            mockUserRepository.Verify(repo => repo.UserExists(username), Times.Once);
            mockReplyRepository.Verify(repo => repo.GetRepliesFromUser(username), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>()), Times.Exactly(repliesFromUser.Count));
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void GetRepliesMadeByUser_Throws_EntityNotFoundException_WhenUserDoesNotExist()
        {
            // Arrange
            var nonExistentUsername = "nonExistentUser";
            var mockReplyRepository = new Mock<IReplyRepository>();
            var mockUserRepository = new Mock<IUsersRepository>();
            var mockPostsRepository = new Mock<IPostsRepository>();
            var mockMapper = new Mock<IMapper>();

            // Set up mock response for UserExists method
            mockUserRepository.Setup(repo => repo.UserExists(nonExistentUsername)).Returns(false);

            var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

            // Act
            replyService.GetRepliesMadeByUser(nonExistentUsername);

            // Assert
            // Expecting an EntityNotFoundException to be thrown
        }
    }
}
