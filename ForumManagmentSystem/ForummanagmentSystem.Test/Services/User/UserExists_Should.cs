
namespace ForummanagmentSystem.Test.Services.User
{
    [TestClass]
    public class UserExists_Should
    {
        [TestMethod]
        public void Returns_True_When_UserExists()
        {
            // Arrange
            var existingUsername = "existingUser";

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for UserExists method (user exists)
            mockRepository.Setup(repo => repo.UserExists(existingUsername)).Returns(true);

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.UserExists(existingUsername);

            // Assert
            Assert.IsTrue(result);

            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.UserExists(existingUsername), Times.Once);
        }

        [TestMethod]
        public void Returns_False_When_UserDoesNotExist()
        {
            // Arrange
            var nonExistingUsername = "nonExistingUser";

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for UserExists method (user does not exist)
            mockRepository.Setup(repo => repo.UserExists(nonExistingUsername)).Returns(false);

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.UserExists(nonExistingUsername);

            // Assert
            Assert.IsFalse(result);

            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.UserExists(nonExistingUsername), Times.Once);
        }
    }
}
