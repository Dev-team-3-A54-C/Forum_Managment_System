
namespace ForummanagmentSystem.Test.Services.User
{
    [TestClass]
    public class GetUser_Should
    {
        [TestMethod]
        public void Returns_UserResponseDTO_When_UserExists()
        {
            // Arrange
            var username = "ExistingUser";
            var userDb = new UserDb { Id = Guid.NewGuid(), Username = username };
            var userResponseDto = new UserResponseDTO { Username = userDb.Username };

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for GetByName method (user exists)
            mockRepository.Setup(repo => repo.GetByName(username)).Returns(userDb);

            // Set up a mock response for AutoMapper
            mockMapper.Setup(mapper => mapper.Map<UserResponseDTO>(userDb)).Returns(userResponseDto);

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.GetUser(username);

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions based on the expected behavior of your code
            Assert.AreEqual(userResponseDto.Username, result.Username);

            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.GetByName(username), Times.Once);
            // Verify that AutoMapper was called
            mockMapper.Verify(mapper => mapper.Map<UserResponseDTO>(userDb), Times.Once);
        }

        [TestMethod]
        public void Returns_UserResponseDTO_When_UserIdExists()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var userDb = new UserDb { Id = userId, Username = "ExistingUser" };
            var userResponseDto = new UserResponseDTO {Username = userDb.Username };

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for GetById method (user exists)
            mockRepository.Setup(repo => repo.GetById(userId)).Returns(userDb);

            // Set up a mock response for AutoMapper
            mockMapper.Setup(mapper => mapper.Map<UserResponseDTO>(userDb)).Returns(userResponseDto);

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.GetUser(userId);

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions based on the expected behavior of your code
            Assert.AreEqual(userResponseDto.Username, result.Username);

            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.GetById(userId), Times.Once);
            // Verify that AutoMapper was called
            mockMapper.Verify(mapper => mapper.Map<UserResponseDTO>(userDb), Times.Once);
        }
    }
}
