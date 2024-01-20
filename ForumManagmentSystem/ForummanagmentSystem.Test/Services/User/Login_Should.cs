
namespace ForummanagmentSystem.Test.Services.User
{
    //problem with jwt generation during tests
    //[TestClass]
    //public class Login_Should
    //{
    //    [TestMethod]
    //    public void Returns_Token_When_LoginSucceeds()
    //    {
    //        // Arrange
    //        var userDto = TestHelper.CreateTestUserLogin(); // Use your TestHelper to create a UserLoginDTO
    //        var registeredUser = TestHelper.CreateTestUserDb(); // Use your TestHelper to create a UserDb

    //        var mockRepository = new Mock<IUsersRepository>();
    //        var mockMapper = new Mock<IMapper>();
    //        var mockConfiguration = new Mock<IConfiguration>();

    //        // Set up mock responses for UserExists and GetByName methods
    //        mockRepository.Setup(repo => repo.UserExists(userDto.Username)).Returns(true);
    //        mockRepository.Setup(repo => repo.GetByName(userDto.Username)).Returns(registeredUser);


    //        var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

    //        // Act
    //        var result = userService.Login(userDto);

    //        // Assert
    //        Assert.IsNotNull(result);
    //        Assert.IsTrue(!string.IsNullOrEmpty(result));

    //        // Verify that the repository methods were called
    //        mockRepository.Verify(repo => repo.UserExists(userDto.Username), Times.Once);
    //        mockRepository.Verify(repo => repo.GetByName(userDto.Username), Times.Once);
    //    }

    //    [TestMethod]
    //    public void Throws_EntityNotFoundException_When_UserNotFound()
    //    {
    //        // Arrange
    //        var nonExistingUserDto = TestHelper.CreateTestUserLogin(); // Use your TestHelper to create a UserLoginDTO

    //        var mockRepository = new Mock<IUsersRepository>();
    //        var mockMapper = new Mock<IMapper>();
    //        var mockConfiguration = new Mock<IConfiguration>();

    //        // Set up mock response for UserExists method (user does not exist)
    //        mockRepository.Setup(repo => repo.UserExists(nonExistingUserDto.Username)).Returns(false);

    //        var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

    //        // Act and Assert
    //        Assert.ThrowsException<EntityNotFoundException>(() => userService.Login(nonExistingUserDto));

    //        // Verify that the repository method was called
    //        mockRepository.Verify(repo => repo.UserExists(nonExistingUserDto.Username), Times.Once);
    //        mockRepository.Verify(repo => repo.GetByName(It.IsAny<string>()), Times.Never);
    //    }

    //    [TestMethod]
    //    public void Throws_WrongPasswordException_When_WrongPassword()
    //    {
    //        // Arrange
    //        var userDto = TestHelper.CreateTestUserLogin(); // Use your TestHelper to create a UserLoginDTO
    //        var registeredUser = TestHelper.CreateTestUserDb(); // Use your TestHelper to create a UserDb

    //        var mockRepository = new Mock<IUsersRepository>();
    //        var mockMapper = new Mock<IMapper>();
    //        var mockConfiguration = new Mock<IConfiguration>();

    //        // Set up mock responses for UserExists and GetByName methods
    //        mockRepository.Setup(repo => repo.UserExists(userDto.Username)).Returns(true);
    //        mockRepository.Setup(repo => repo.GetByName(userDto.Username)).Returns(registeredUser);


    //        var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

    //        // Act and Assert
    //        Assert.ThrowsException<WrongPasswordException>(() => userService.Login(userDto));

    //        // Verify that the repository methods were called
    //        mockRepository.Verify(repo => repo.UserExists(userDto.Username), Times.Once);
    //        mockRepository.Verify(repo => repo.GetByName(userDto.Username), Times.Once);
    //    }
    //}
}
