
using Moq;

namespace ForummanagmentSystem.Test.Services.Replies
{
    [TestClass]
    public class AddLike_Should
    {
        [TestMethod]
        public void UserHasNotLikedReply_Returns_ReplyResponseDTO()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var replyId = Guid.NewGuid();
            var replyLike = new ReplyLikesDb { UserId = userId, ReplyId = replyId };

            var mockReplyRepository = new Mock<IReplyRepository>();
            var mockUserRepository = new Mock<IUsersRepository>();
            var mockPostsRepository = new Mock<IPostsRepository>();
            var mockMapper = new Mock<IMapper>();

            // Set up mock responses for GetById, AddLike, and Map methods
            mockUserRepository.Setup(repo => repo.GetById(userId)).Returns(new UserDb { MyLikedReplies = new List<ReplyLikesDb>() });
            mockReplyRepository.Setup(repo => repo.GetById(replyId)).ReturnsAsync(new ReplyDb());
            mockReplyRepository.Setup(repo => repo.AddLike(replyLike)).ReturnsAsync(new ReplyDb());
            mockMapper.Setup(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>())).Returns((ReplyDb r) => new ReplyResponseDTO { Content = r.Content }); // Adjust the mapping as per your actual mapping logic

            var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

            // Act
            var result = replyService.AddLike(userId, replyId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ReplyResponseDTO));

            // Verify that the repository methods were called
            mockUserRepository.Verify(repo => repo.GetById(userId), Times.Once);
            mockReplyRepository.Verify(repo => repo.GetById(replyId), Times.Once);
            //mockReplyRepository.Verify(repo => repo.AddLike(replyLike), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>()), Times.Once);
        }

        [TestMethod]
        public void UserHasLikedReply_RemovesLikeAndReturns_ReplyResponseDTO()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var replyId = Guid.NewGuid();
            var replyLike = new ReplyLikesDb { UserId = userId, ReplyId = replyId };

            var mockReplyRepository = new Mock<IReplyRepository>();
            var mockUserRepository = new Mock<IUsersRepository>();
            var mockPostsRepository = new Mock<IPostsRepository>();
            var mockMapper = new Mock<IMapper>();

            // Set up mock responses for GetById, RemoveLike, and Map methods
            mockUserRepository.Setup(repo => repo.GetById(userId)).Returns(new UserDb { MyLikedReplies = new List<ReplyLikesDb> { replyLike } });
            mockReplyRepository.Setup(repo => repo.GetById(replyId)).ReturnsAsync(new ReplyDb());
            mockReplyRepository.Setup(repo => repo.RemoveLike(replyLike)).ReturnsAsync(new ReplyDb());
            mockMapper.Setup(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>())).Returns((ReplyDb r) => new ReplyResponseDTO { Content = r.Content }); // Adjust the mapping as per your actual mapping logic

            var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

            // Act
            var result = replyService.AddLike(userId, replyId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ReplyResponseDTO));

            // Verify that the repository methods were called
            mockUserRepository.Verify(repo => repo.GetById(userId), Times.Once);
            mockReplyRepository.Verify(repo => repo.GetById(replyId), Times.Once);
            //mockReplyRepository.Verify(repo => repo.RemoveLike(replyLike), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>()), Times.Once);
        }
    }
}
