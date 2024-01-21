using AutoMapper;
using ForumManagmentSystem.Core.Helpers;
using ForumManagmentSystem.Core.ResponseDTOs;
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
	public class GetById_Should
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
		public void GetById_ExistingTagId_ReturnsTagResponseDTO()
		{
			// Arrange
			var tagId = Guid.NewGuid();

			var existingTagDb = new TagDb { Id = tagId, Name = "ExistingTag" };
			tagRepositoryMock.Setup(repo => repo.GetById(tagId)).ReturnsAsync(existingTagDb);
			mapperMock.Setup(mapper => mapper.Map<TagResponseDTO>(It.IsAny<TagDb>()))
				.Returns((TagDb tagDb) => new TagResponseDTO { Id = tagDb.Id.ToString(), Name = tagDb.Name });

			// Act
			var result = tagService.GetById(tagId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(existingTagDb.Id.ToString(), result.Id);
			Assert.AreEqual(existingTagDb.Name, result.Name);

		}

		[TestMethod]
		public void GetById_NonExistingTagId_ReturnsNull()
		{
			// Arrange
			var nonExistingTagId = Guid.NewGuid();

			tagRepositoryMock.Setup(repo => repo.GetById(nonExistingTagId)).ReturnsAsync((TagDb)null);

			// Act
			var result = tagService.GetById(nonExistingTagId);

			// Assert
			Assert.IsNull(result);
		}
	}
	
}
