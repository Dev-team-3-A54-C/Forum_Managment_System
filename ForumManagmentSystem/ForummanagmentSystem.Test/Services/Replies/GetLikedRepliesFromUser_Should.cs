
using Moq;

namespace ForummanagmentSystem.Test.Services.Replies
{
    [TestClass]
    public class GetLikedRepliesFromUser_Should
    {
        //[TestMethod]
        //public void GetLikedRepliesFromUser_Returns_ReplyResponseDTOs()
        //{
        //    // Arrange
        //    var username = "testUser";
        //    var likedReplies = new List<ReplyDb>
        //    {
        //        TestHelper.CreateReplyDb(),
        //        TestHelper.CreateReplyDb(),
        //        TestHelper.CreateReplyDb()
        //    };

        //    var mockReplyRepository = new Mock<IReplyRepository>();
        //    var mockUserRepository = new Mock<IUsersRepository>();
        //    var mockPostsRepository = new Mock<IPostsRepository>();
        //    var mockMapper = new Mock<IMapper>();

        //    // Set up mock responses for UserExists and GetLikedRepliesFromUser methods
        //    mockUserRepository.Setup(repo => repo.UserExists(username)).Returns(true);
        //    mockReplyRepository.Setup(repo => repo.GetLikedRepliesFromUser(username)).ReturnsAsync(likedReplies);
        //    mockMapper.Setup(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>())).Returns((ReplyDb r) => new ReplyResponseDTO { Content = r.Content }); // Adjust the mapping as per your actual mapping logic

        //    var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

        //    // Act
        //    var result = replyService.GetLikedRepliesFromUser(username);

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.IsInstanceOfType(result, typeof(IEnumerable<ReplyResponseDTO>));
        //    Assert.AreEqual(likedReplies.Count, result.Count());

        //    // Verify that the repository methods were called
        //    mockUserRepository.Verify(repo => repo.UserExists(username), Times.Once);
        //    mockReplyRepository.Verify(repo => repo.GetLikedRepliesFromUser(username), Times.Once);
        //    mockMapper.Verify(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>()), Times.Exactly(likedReplies.Count));
        //}
    }
}
