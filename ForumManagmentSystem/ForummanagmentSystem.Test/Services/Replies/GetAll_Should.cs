
namespace ForummanagmentSystem.Test.Services.Replies
{
    [TestClass]
    public class GetAll_Should
    {
        [TestMethod]
        public void Returns_ReplyResponseDTOs()
        {
            // Arrange
            var replies = new List<ReplyDb>
            {
                TestHelper.CreateReplyDb(),
                TestHelper.CreateReplyDb(),
                TestHelper.CreateReplyDb()
            };

            var mockReplyRepository = new Mock<IReplyRepository>();
            var mockUserRepository = new Mock<IUsersRepository>();
            var mockPostsRepository = new Mock<IPostsRepository>();
            var mockMapper = new Mock<IMapper>();

            // Set up mock responses for GetAll method
            mockReplyRepository.Setup(repo => repo.GetAll()).ReturnsAsync(replies);
            mockMapper.Setup(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>())).Returns((ReplyDb r) => new ReplyResponseDTO {Content = r.Content }); // Adjust the mapping as per your actual mapping logic

            var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

            // Act
            var result = replyService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<ReplyResponseDTO>));
            Assert.AreEqual(replies.Count, result.Count());

            // Verify that the repository method was called
            mockReplyRepository.Verify(repo => repo.GetAll(), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>()), Times.Exactly(replies.Count));
        }
    }
}
