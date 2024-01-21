using AutoMapper;
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
	public class GetByName_Should
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
		public void Return_Correct_Tag()
		{
			// Arrange
			var tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			TagDb expectedResponse = TestHelper.GetTestTag();
			tagRepositoryMock.Setup(repo => repo.GetByName(expectedResponse.Name)).ReturnsAsync(expectedResponse);

			// Act
			var result = tagService.GetByName(expectedResponse.Name);

			// Assert
			Assert.AreEqual(expectedResponse, result);
		}
		[TestMethod]
		public void Throw_EntityNotFoundException_When_Non_Existent()
		{
			// Arrange
			var tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			var nonExistentTagName = "NonExistentTag";
			tagRepositoryMock.Setup(repo => repo.GetByName(nonExistentTagName)).ReturnsAsync((TagDb)null);

			// Act and Assert
			Assert.ThrowsException<EntityNotFoundException>(() => tagService.GetByName(nonExistentTagName));
		}
	}
}
