using AutoMapper;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Infrastructure.Repositories;
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
		Mock<IMapper> mapperMock;
		ITagService tagService;

		[TestInitialize]
		public void Init()
		{
			usersRepositoryMock = new Mock<IUsersRepository>();
			tagRepositoryMock = new Mock<ITagRepository>();
			mapperMock = new Mock<IMapper>();
			tagService = new TagService(tagRepositoryMock.Object, mapperMock.Object, usersRepositoryMock.Object);
		}

		[TestMethod]
		public void GetByName_ExistingTagName_ReturnsTagResponseDTO()
		{
			// Arrange
			var tagName = "ExistingTag";

			var existingTagDb = new TagDb { Id = Guid.NewGuid(), Name = tagName };
			tagRepositoryMock.Setup(repo => repo.GetByName(tagName)).ReturnsAsync(existingTagDb);
			mapperMock.Setup(mapper => mapper.Map<TagResponseDTO>(It.IsAny<TagDb>()))
				.Returns((TagDb tagDb) => new TagResponseDTO { Id = tagDb.Id.ToString(), Name = tagDb.Name });

			// Act
			var result = tagService.GetByName(tagName);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(existingTagDb.Id.ToString(), result.Id);
			Assert.AreEqual(existingTagDb.Name, result.Name);
		}

		[TestMethod]
		public void GetByName_NonExistingTagName_ReturnsNull()
		{
			// Arrange
			var nonExistingTagName = "NonExistingTag";

			tagRepositoryMock.Setup(repo => repo.GetByName(nonExistingTagName)).ReturnsAsync((TagDb)null);

			// Act
			var result = tagService.GetByName(nonExistingTagName);

			// Assert
			Assert.IsNull(result);
		}
	}
}
