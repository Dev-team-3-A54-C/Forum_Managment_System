
namespace ForummanagmentSystem.Test.Services.Replies
{
    [TestClass]
    public class Get_Should
    {
        [TestMethod]
        public void Returns_ReplyResponseDTO()
        {
            // Arrange
            var replyId = Guid.NewGuid();
            var replyDb = TestHelper.CreateReplyDb();
            replyDb.Id = replyId;

            var mockReplyRepository = new Mock<IReplyRepository>();
            var mockUserRepository = new Mock<IUsersRepository>();
            var mockPostsRepository = new Mock<IPostsRepository>();
            var mockMapper = new Mock<IMapper>();

            // Set up mock responses for GetById method
            mockReplyRepository.Setup(repo => repo.GetById(replyId)).ReturnsAsync(replyDb);
            mockMapper.Setup(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>())).Returns((ReplyDb r) => new ReplyResponseDTO { Content = r.Content }); // Adjust the mapping as per your actual mapping logic

            var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

            // Act
            var result = replyService.Get(replyId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ReplyResponseDTO));

            // Verify that the repository method was called
            mockReplyRepository.Verify(repo => repo.GetById(replyId), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>()), Times.Once);
        }
    }
}
