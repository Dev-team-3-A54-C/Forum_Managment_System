using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForummanagmentSystem.Test.Services.Tags
{
	[TestClass]
	public class Create_Should
	{
		Mock<IUsersRepository> usersRepositoryMock;
		Mock<ITagRepository> tagRepositoryMock;
		Mock<IMapper> mapper;

		[TestInitialize]
		public void Init()
		{
			usersRepositoryMock = new Mock<IUsersRepository>();
			tagRepositoryMock = new Mock<ITagRepository>();
			mapper = new Mock<IMapper>();
		}

		[TestMethod]
		public void Return_Correct_Object()
		{
			// Arrange
			var tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			var adminUser = new UserDb() { Id = new Guid(), Username = "Admin" , IsAdmin = true};
			usersRepositoryMock.Setup(repo => repo.GetById(adminUser.Id)).Returns(adminUser);

			TagDTO expected = TestHelper.GetTestTagDTO();
			tagRepositoryMock.Setup(repo => repo.DoesNameExist(expected.Name)).ReturnsAsync(false);

			// Act
			var actual = tagService.Create(adminUser.Id, expected);

			// Assert
			Assert.IsNotNull(actual);
			Assert.AreEqual(expected.Name, actual.Name);
		}
		[TestMethod]
		public void Throw_Unauthorized_If_User_Is_Not_Admin()
		{
			// Arrange
			var tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			var regularUser = new UserDb() { Id = new Guid(), Username = "RegularUser" , IsAdmin = false};
			usersRepositoryMock.Setup(repo => repo.GetById(regularUser.Id)).Returns(regularUser);
			// Act and Assert
			TagDTO testTag = TestHelper.GetTestTagDTO();
			Assert.ThrowsException<UnauthorizedOperationException>(() =>
				tagService.Create(regularUser.Id, testTag));
		}

		[TestMethod]
		public void Throw_NameDuplicationException_If_Tag_Exists()
		{
			// Arrange
			var tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			var adminUser = new UserDb() { Username = "Admin", IsAdmin = true };
			usersRepositoryMock.Setup(repo => repo.GetById(adminUser.Id)).Returns(adminUser);

			var existingTagName = "ExistingTag";
			tagRepositoryMock.Setup(repo => repo.DoesNameExist(existingTagName)).ReturnsAsync(true);

			// Act and Assert
			TagDTO testTag = new TagDTO() { Name = existingTagName };
			Assert.ThrowsException<NameDuplicationException>(() =>
				tagService.Create(adminUser.Id, testTag));
		}
	}
}
