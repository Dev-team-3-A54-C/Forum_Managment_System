
using AutoMapper;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using Moq;

namespace ForummanagmentSystem.Test.Services.User
{
    [TestClass]
    public class GetDbUser_Should
    {
        [TestMethod]
        public void Returns_UserDb_When_UserExists()
        {
            // Arrange
            var username = "ExistingUser";
            var userDb = new UserDb { Id = Guid.NewGuid(), Username = username };

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for GetByName method (user exists)
            mockRepository.Setup(repo => repo.GetByName(username)).Returns(userDb);

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.GetDbUser(username);

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions based on the expected behavior of your code
            Assert.AreEqual(userDb.Id, result.Id);
            Assert.AreEqual(userDb.Username, result.Username);

            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.GetByName(username), Times.Once);
        }
    }
}
