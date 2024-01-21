
namespace ForummanagmentSystem.Test.Services.Replies
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public void Returns_ReplyResponseDTO_When_CreationSucceeds()
        {
            // Arrange
            var replyDto = TestHelper.CreateReplyDto(); // Use your TestHelper to create a ReplyDTO
            var user = TestHelper.CreateUserDb(); // Use your TestHelper to create a UserDb
            var post = TestHelper.CreatePostDb(); // Use your TestHelper to create a PostDb
            var createdReply = TestHelper.CreateReplyDb(); // Use your TestHelper to create a ReplyDb
            var replyResponseDto = TestHelper.CreateReplyResponseDto();

            var mockUserRepository = new Mock<IUsersRepository>();
            var mockPostsRepository = new Mock<IPostsRepository>();
            var mockReplyRepository = new Mock<IReplyRepository>();
            var mockMapper = new Mock<IMapper>();

            // Set up mock responses for UserExists, GetByName, PostExists, GetByTitle, and Create methods
            mockUserRepository.Setup(repo => repo.UserExists(replyDto.CreatedBy)).Returns(true);
            mockUserRepository.Setup(repo => repo.GetByName(replyDto.CreatedBy)).Returns(user);

            mockPostsRepository.Setup(repo => repo.PostExists(replyDto.PostTitle)).Returns(true);
            mockPostsRepository.Setup(repo => repo.GetByTitle(replyDto.PostTitle)).Returns(post);

            mockMapper.Setup(mapper => mapper.Map<ReplyDb>(replyDto)).Returns(createdReply);
            mockMapper.Setup(mapper => mapper.Map<ReplyResponseDTO>(It.IsAny<ReplyDb>())).Returns(replyResponseDto);
            mockReplyRepository.Setup(repo => repo.Create(createdReply)).ReturnsAsync(createdReply);

            var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

            // Act
            var result = replyService.Create(replyDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ReplyResponseDTO));

            // Verify that the repository methods were called
            //mockUserRepository.Verify(repo => repo.UserExists(replyDto.CreatedBy), Times.Once);
            //mockUserRepository.Verify(repo => repo.GetByName(replyDto.CreatedBy), Times.Once);

            //mockPostsRepository.Verify(repo => repo.PostExists(replyDto.PostTitle), Times.Once);
            //mockPostsRepository.Verify(repo => repo.GetByTitle(replyDto.PostTitle), Times.Once);

            //mockMapper.Verify(mapper => mapper.Map<ReplyDb>(replyDto), Times.Once);
            //mockReplyRepository.Verify(repo => repo.Create(createdReply), Times.Once);
        }

        [TestMethod]
        public void Throws_EntityNotFoundException_When_UserDoesNotExist()
        {
            // Arrange
            var nonExistingUserDto = TestHelper.CreateReplyDto(); // Use your TestHelper to create a ReplyDTO

            var mockUserRepository = new Mock<IUsersRepository>();
            var mockPostsRepository = new Mock<IPostsRepository>();
            var mockReplyRepository = new Mock<IReplyRepository>();
            var mockMapper = new Mock<IMapper>();

            // Set up mock response for UserExists method (user does not exist)
            mockUserRepository.Setup(repo => repo.UserExists(nonExistingUserDto.CreatedBy)).Returns(false);

            var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() => replyService.Create(nonExistingUserDto));

            // Verify that the repository method was called
            mockUserRepository.Verify(repo => repo.UserExists(nonExistingUserDto.CreatedBy), Times.Once);
            mockUserRepository.Verify(repo => repo.GetByName(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void Throws_EntityNotFoundException_When_PostDoesNotExist()
        {
            // Arrange
            var nonExistingPostDto = TestHelper.CreateReplyDto(); // Use your TestHelper to create a ReplyDTO

            var mockUserRepository = new Mock<IUsersRepository>();
            var mockPostsRepository = new Mock<IPostsRepository>();
            var mockReplyRepository = new Mock<IReplyRepository>();
            var mockMapper = new Mock<IMapper>();

            // Set up mock responses for UserExists, GetByName, PostExists, and GetByTitle methods
            mockUserRepository.Setup(repo => repo.UserExists(nonExistingPostDto.CreatedBy)).Returns(true);
            mockUserRepository.Setup(repo => repo.GetByName(nonExistingPostDto.CreatedBy)).Returns(TestHelper.CreateUserDb());

            mockPostsRepository.Setup(repo => repo.PostExists(nonExistingPostDto.PostTitle)).Returns(false);

            var replyService = new ReplyService(mockReplyRepository.Object, mockUserRepository.Object, mockPostsRepository.Object, mockMapper.Object);

            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() => replyService.Create(nonExistingPostDto));

            // Verify that the repository methods were called
            mockUserRepository.Verify(repo => repo.UserExists(nonExistingPostDto.CreatedBy), Times.Once);
            //mockUserRepository.Verify(repo => repo.GetByName(nonExistingPostDto.CreatedBy), Times.Once);

            mockPostsRepository.Verify(repo => repo.PostExists(nonExistingPostDto.PostTitle), Times.Once);
            //mockPostsRepository.Verify(repo => repo.GetByTitle(It.IsAny<string>()), Times.Never);
        }
    }
}
