
using ForumManagmentSystem.Core.RequestDTOs;

namespace ForummanagmentSystem.Test.Services.User
{
    [TestClass]
    public class Update_Should
    {
        [TestMethod]
        public void Returns_UserResponseDTO_When_UserExists_And_UpdatedSuccessfully()
        {
            // Arrange
            var username = "test";
            var id = Guid.NewGuid();
            var editUserDto = new EditUserDTO { /* Set properties for the edit user DTO */ };
            var updatedUserDb = new UserDb { Id=id,  Username = username, /* Set properties for the updated user DB */ };
            var updatedUserResponseDto = new UserResponseDTO { Username = username, /* Set properties for the updated user response DTO */ };

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for Update method (user exists and update is successful)
            mockRepository.Setup(repo => repo.Update(id, It.IsAny<UserDb>())).Returns(updatedUserDb);

            // Set up a mock response for AutoMapper
            mockMapper.Setup(mapper => mapper.Map<UserResponseDTO>(updatedUserDb)).Returns(updatedUserResponseDto);

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.Update(id, editUserDto);

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions based on the expected behavior of your code
            Assert.AreEqual(updatedUserResponseDto.Username, result.Username);
            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.Update(id, It.IsAny<UserDb>()), Times.Once);
            // Verify that AutoMapper was called
            mockMapper.Verify(mapper => mapper.Map<UserResponseDTO>(updatedUserDb), Times.Once);
        }
    }
}
