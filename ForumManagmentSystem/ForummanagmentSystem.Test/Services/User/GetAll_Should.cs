
namespace ForummanagmentSystem.Test.Services.User
{
    [TestClass]
    public class GetAll_Should
    {
        [TestMethod]
        public void Returns_ListOfUserResponseDTO_When_UsersExist()
        {
            // Arrange
            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for the GetAll method
            var userList = new List<UserDb>
        {
            new UserDb { Id = Guid.NewGuid(), Username = "User1" },
            new UserDb { Id = Guid.NewGuid(), Username = "User2" },
            // Add more users as needed
        };
            mockRepository.Setup(repo => repo.GetAll()).Returns(userList);

            // Set up a mock response for AutoMapper
            mockMapper.Setup(mapper => mapper.Map<UserResponseDTO>(It.IsAny<UserDb>()))
                .Returns((UserDb user) => new UserResponseDTO { Username = user.Username });

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userList.Count, result.Count);

            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.GetAll(), Times.Once);
            // Verify that AutoMapper was called for each user in the list
            mockMapper.Verify(mapper => mapper.Map<UserResponseDTO>(It.IsAny<UserDb>()), Times.Exactly(userList.Count));
        }

        [TestMethod]
        public void Returns_EmptyList_When_NoUsersExist()
        {
            // Arrange
            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for the GetAll method (return an empty list)
            mockRepository.Setup(repo => repo.GetAll()).Returns(new List<UserDb>());

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);

            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.GetAll(), Times.Once);
            // Verify that AutoMapper was not called (since there are no users)
            mockMapper.Verify(mapper => mapper.Map<UserResponseDTO>(It.IsAny<UserDb>()), Times.Never);
        }
    }
}
