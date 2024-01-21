
using ForumManagmentSystem.Core.RequestDTOs;

namespace ForummanagmentSystem.Test.Services.Replies
{
    [TestClass]
    public class Update_Should
    {
        [TestMethod]
        public void ReplyExists_Returns_UpdatedReplyResponseDTO()
        {
            // Arrange
            var id = Guid.NewGuid();
            var replyDTO = new ReplyDTO { /* initialize replyDTO properties */ };

            var mockReplyRepository = new Mock<IReplyRepository>();
            var mockUserRepository = new Mock<IUsersRepository>();
            var mockPostsRepository = new Mock<IPostsRepository>();
            var mockMapper = new Mock<IMapper>();

            // Set up mock responses for ReplyExist, Update, and Map methods
            mockReplyRepository.Setup(repo => repo.ReplyExist(id)).ReturnsAsync(true);
            mockReplyRepository.Setup(repo => repo.Update(id, It.IsAny<ReplyDb>())).ReturnsAsync(new ReplyDb()); // Adjust the return type as per your actual implementation
            mockMapper.Setup(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>())).Returns((ReplyDb r) => new ReplyResponseDTO { Content = r.Content }); // Adjust the mapping as per your actual mapping logic

            var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

            // Act
            var result = replyService.Update(id, replyDTO);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ReplyResponseDTO));

            // Verify that the repository methods were called
            mockReplyRepository.Verify(repo => repo.ReplyExist(id), Times.Once);
            mockReplyRepository.Verify(repo => repo.Update(id, It.IsAny<ReplyDb>()), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void ReplyDoesNotExist_Throws_EntityNotFoundException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var replyDTO = new ReplyDTO { /* initialize replyDTO properties */ };

            var mockReplyRepository = new Mock<IReplyRepository>();
            var mockUserRepository = new Mock<IUsersRepository>();
            var mockPostsRepository = new Mock<IPostsRepository>();
            var mockMapper = new Mock<IMapper>();

            // Set up mock response for ReplyExist
            mockReplyRepository.Setup(repo => repo.ReplyExist(id)).ReturnsAsync(false);

            var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

            // Act & Assert
            replyService.Update(id, replyDTO); // This should throw EntityNotFoundException
        }
    }
}
