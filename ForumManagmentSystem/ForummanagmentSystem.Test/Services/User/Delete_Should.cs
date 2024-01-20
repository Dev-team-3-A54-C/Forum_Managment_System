
namespace ForummanagmentSystem.Test.Services.User
{
    [TestClass]
    public class Delete_Should
    {
        [TestMethod]
        public void Delete_Returns_UserResponseDTO_When_UserIsAdmin_And_DeletedSuccessfully()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var username = "AdminUser";
            var adminUserDb = new UserDb { Id = userId, Username = username, IsAdmin = true };
            var deletedUserDb = new UserDb { Id = userId, Username = username, IsAdmin = true };
            var deletedUserResponseDto = new UserResponseDTO { Username = username};

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for GetByName method (admin user exists)
            mockRepository.Setup(repo => repo.GetByName(username)).Returns(adminUserDb);

            // Set up a mock response for Delete method (user is an admin and deletion is successful)
            mockRepository.Setup(repo => repo.Delete(userId)).Returns(deletedUserDb);

            // Set up a mock response for AutoMapper
            mockMapper.Setup(mapper => mapper.Map<UserResponseDTO>(deletedUserDb)).Returns(deletedUserResponseDto);

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.Delete(userId, username);

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions based on the expected behavior of your code
            Assert.AreEqual(deletedUserResponseDto.Username, result.Username);
            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.GetByName(username), Times.Once);
            mockRepository.Verify(repo => repo.Delete(userId), Times.Once);
            // Verify that AutoMapper was called
            mockMapper.Verify(mapper => mapper.Map<UserResponseDTO>(deletedUserDb), Times.Once);
        }

        [TestMethod]
        public void Delete_Throws_UnauthorizedOperationException_When_UserIsNotAdmin()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var username = "NonAdminUser";
            var nonAdminUserDb = new UserDb { Id = userId, Username = username, IsAdmin = false };

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for GetByName method (non-admin user exists)
            mockRepository.Setup(repo => repo.GetByName(username)).Returns(nonAdminUserDb);

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act & Assert
            Assert.ThrowsException<UnauthorizedOperationException>(() => userService.Delete(userId, username));

            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.GetByName(username), Times.Once);
            // Verify that Delete and AutoMapper were not called (since the user is not an admin)
            mockRepository.Verify(repo => repo.Delete(It.IsAny<Guid>()), Times.Never);
            mockMapper.Verify(mapper => mapper.Map<UserResponseDTO>(It.IsAny<UserDb>()), Times.Never);
        }
    }
}
