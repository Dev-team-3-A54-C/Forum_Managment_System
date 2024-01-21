
namespace ForummanagmentSystem.Test.Services.User
{
    [TestClass]
    public class GetCount_Should
    {
        [TestMethod]
        public void Returns_CorrectCount_When_UsersExist()
        {
            // Arrange
            var userCount = 5;

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for the Count method
            mockRepository.Setup(repo => repo.Count()).Returns(userCount);

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.GetCount();

            // Assert
            Assert.AreEqual(userCount, result);

            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.Count(), Times.Once);
        }

        [TestMethod]
        public void Returns_Zero_When_NoUsersExist()
        {
            // Arrange
            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for the Count method (no users exist)
            mockRepository.Setup(repo => repo.Count()).Returns(0);

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.GetCount();

            // Assert
            Assert.AreEqual(0, result);

            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.Count(), Times.Once);
        }
    }
}
