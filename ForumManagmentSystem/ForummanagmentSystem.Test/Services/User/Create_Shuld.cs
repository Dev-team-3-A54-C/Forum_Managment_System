﻿
namespace ForummanagmentSystem.Test.Services.User
{
    [TestClass]
    public class Create_Shuld
    {

        [TestMethod]
        public void Returns_UserResponseDTO_When_UserDoesNotExist()
        {
            // Arrange
            var userDto = TestHelper.CreateTestUser(); // Use your TestHelper to get a UserDTO

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for UserExists method (user does not exist)
            mockRepository.Setup(repo => repo.UserExists(userDto.Username)).Returns(false);

            // Set up a mock response for the Create method
            var createdUserDb = new UserDb { Id = Guid.NewGuid(), Username = userDto.Username, /* Include other properties as needed */ };
            mockRepository.Setup(repo => repo.Create(It.IsAny<UserDb>())).Returns(createdUserDb);

            // Set up a mock response for AutoMapper
            mockMapper.Setup(mapper => mapper.Map<UserDb>(userDto)).Returns(new UserDb());
            mockMapper.Setup(mapper => mapper.Map<UserResponseDTO>(It.IsAny<UserDb>())).Returns(new UserResponseDTO());

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.CreateUser(userDto);

            // Assert
            Assert.IsNotNull(result);
            
            // Verify that the repository methods were called with the correct arguments and number of times
            mockRepository.Verify(repo => repo.UserExists(userDto.Username), Times.Once);
            mockRepository.Verify(repo => repo.Create(It.IsAny<UserDb>()), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<UserDb>(userDto), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(NameDuplicationException))]
        public void Throws_NameDuplicationException_When_UserExists()
        {
            // Arrange
            var userDto = TestHelper.CreateTestUser(); // Use your TestHelper to get a UserDTO

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for UserExists method (user already exists)
            mockRepository.Setup(repo => repo.UserExists(userDto.Username)).Returns(true);

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act and Assert
            // This test case expects an exception of type NameDuplicationException to be thrown
            userService.CreateUser(userDto);
        }
    }
}
