
namespace ForummanagmentSystem.Test.Services.Replies
{
    [TestClass]
    public class Delete_Should
    {
        [TestMethod]
        public void ReplyExists_Returns_DeletedReplyResponseDTO()
        {
            // Arrange
            var replyId = Guid.NewGuid();

            var mockReplyRepository = new Mock<IReplyRepository>();
            var mockUserRepository = new Mock<IUsersRepository>();
            var mockPostsRepository = new Mock<IPostsRepository>();
            var mockMapper = new Mock<IMapper>();

            // Set up mock response for Delete and Map methods
            mockReplyRepository.Setup(repo => repo.Delete(replyId)).ReturnsAsync(new ReplyDb()); // Adjust the return type as per your actual implementation
            mockMapper.Setup(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>())).Returns((ReplyDb r) => new ReplyResponseDTO { Content = r.Content }); // Adjust the mapping as per your actual mapping logic

            var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

            // Act
            var result = replyService.Delete(replyId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ReplyResponseDTO));

            // Verify that the repository methods were called
            mockReplyRepository.Verify(repo => repo.Delete(replyId), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>()), Times.Once);
        }
    }
}
