
using ForumManagmentSystem.Infrastructure.QueryParameters;

namespace ForummanagmentSystem.Test.Services.User
{
    [TestClass]
    public class FilterBy_Should
    {
        [TestMethod]
        public void Returns_ListOfUserResponseDTO_When_FilteringSucceeds()
        {
            // Arrange
            var userParams = new UserQueryParameters { /* Set properties for user query parameters */ };
            var filteredUserDbs = new List<UserDb> { /* Set up filtered user database objects */ };
            var filteredUserResponseDtos = new List<UserResponseDTO> { /* Set up filtered user response DTOs */ };

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for FilterBy method (filtering is successful)
            mockRepository.Setup(repo => repo.FilterBy(userParams)).Returns(filteredUserDbs);

            // Set up a mock response for AutoMapper
            mockMapper.Setup(mapper => mapper.Map<UserResponseDTO>(It.IsAny<UserDb>()))
                .Returns<UserDb>(userDb => filteredUserResponseDtos.Find(dto => dto.Username == userDb.Username));

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.FilterBy(userParams);

            // Assert
            CollectionAssert.AreEquivalent(filteredUserResponseDtos, (List<UserResponseDTO>)result);

            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.FilterBy(userParams), Times.Once);
            // Verify that AutoMapper was called for each filtered user
            mockMapper.Verify(mapper => mapper.Map<UserResponseDTO>(It.IsAny<UserDb>()), Times.Exactly(filteredUserDbs.Count));
        }

        [TestMethod]
        public void Returns_EmptyList_When_NoUsersMatchFilter()
        {
            // Arrange
            var userParams = new UserQueryParameters { /* Set properties for user query parameters */ };

            var mockRepository = new Mock<IUsersRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            // Set up a mock response for FilterBy method (no users match the filter)
            mockRepository.Setup(repo => repo.FilterBy(userParams)).Returns(new List<UserDb>());

            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockConfiguration.Object);

            // Act
            var result = userService.FilterBy(userParams);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);

            // Verify that the repository method was called
            mockRepository.Verify(repo => repo.FilterBy(userParams), Times.Once);
            // Verify that AutoMapper was not called (since there are no users to map)
            mockMapper.Verify(mapper => mapper.Map<UserResponseDTO>(It.IsAny<UserDb>()), Times.Never);
        }
    }
}
