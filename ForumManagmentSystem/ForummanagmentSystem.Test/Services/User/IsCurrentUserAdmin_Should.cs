
namespace ForummanagmentSystem.Test.Services.User
{
    [TestClass]
    public class IsCurrentUserAdmin_Should
    {
        [TestMethod]
        public void Returns_True_When_UserExists_And_IsAdmin()
        {
            // Arrange
            var currUsername = "ExistingAdminUser";
            var userDb = new UserDb { Id = Guid.NewGuid(), Username = currUsername, IsAdmin = true };

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for GetByName method (user exists)
            mockRepository.Setup(repo => repo.GetByName(currUsername)).Returns(userDb);

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.IsCurrentUserAdmin(currUsername);

            // Assert
            Assert.IsTrue(result);

            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.GetByName(currUsername), Times.Once);
        }

        [TestMethod]
        public void Returns_False_When_UserExists_And_IsNotAdmin()
        {
            // Arrange
            var currUsername = "ExistingNonAdminUser";
            var userDb = new UserDb { Id = Guid.NewGuid(), Username = currUsername, IsAdmin = false };

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for GetByName method (user exists)
            mockRepository.Setup(repo => repo.GetByName(currUsername)).Returns(userDb);

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.IsCurrentUserAdmin(currUsername);

            // Assert
            Assert.IsFalse(result);

            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.GetByName(currUsername), Times.Once);
        }
    }
}
