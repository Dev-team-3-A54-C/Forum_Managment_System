using AutoMapper;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Infrastructure.Data.Models;
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
	public class GetAll_Should
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
		public void Return_Collection()
		{
			// Arrange
			var tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			var expectedTags = TestHelper.GetAllTestTags();

			tagRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(expectedTags);

			// Act
			var result = tagService.GetAll();

			// Assert
			Assert.AreEqual(expectedTags, result);
		}

	}
}
