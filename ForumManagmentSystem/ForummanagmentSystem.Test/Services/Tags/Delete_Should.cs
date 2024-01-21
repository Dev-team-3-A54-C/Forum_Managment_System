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
	public class Delete_Should
	{
		Mock<IUsersRepository> userRepositoryMock;
		Mock<ITagRepository> tagRepositoryMock;
		Mock<IMapper> mapperMock;
		ITagService tagService;

		[TestInitialize]
		public void Init()
		{
			userRepositoryMock = new Mock<IUsersRepository>();
			tagRepositoryMock = new Mock<ITagRepository>();
			mapperMock = new Mock<IMapper>();
			tagService = new TagService(tagRepositoryMock.Object, mapperMock.Object, userRepositoryMock.Object);
		}

		[TestMethod]
		public void Delete_ByTagName_ValidAdminUser_ReturnsTagResponseDTO()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var tagName = "TagToDelete";

			userRepositoryMock.Setup(repo => repo.GetById(userId))
				.Returns(new UserDb { IsAdmin = true, Username = "AdminUser" });

			var deletedTagDb = new TagDb { Id = Guid.NewGuid(), Name = tagName };
			tagRepositoryMock.Setup(repo => repo.Delete(tagName)).ReturnsAsync(deletedTagDb);

			mapperMock.Setup(mapper => mapper.Map<TagResponseDTO>(It.IsAny<TagDb>()))
				.Returns(new TagResponseDTO { Id = deletedTagDb.Id.ToString(), Name = deletedTagDb.Name });

			// Act
			var result = tagService.Delete(userId, tagName);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(deletedTagDb.Id.ToString(), result.Id);
			Assert.AreEqual(deletedTagDb.Name, result.Name);
		}

		[TestMethod]
		public void Delete_ByTagId_ValidAdminUser_ReturnsTagResponseDTO()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var tagId = Guid.NewGuid();

			userRepositoryMock.Setup(repo => repo.GetById(userId))
				.Returns(new UserDb { IsAdmin = true, Username = "AdminUser" });

			var deletedTagDb = new TagDb { Id = tagId, Name = "DeletedTag" };
			tagRepositoryMock.Setup(repo => repo.Delete(tagId)).ReturnsAsync(deletedTagDb);

			mapperMock.Setup(mapper => mapper.Map<TagResponseDTO>(It.IsAny<TagDb>()))
				.Returns(new TagResponseDTO { Id = deletedTagDb.Id.ToString(), Name = deletedTagDb.Name });

			// Act
			var result = tagService.Delete(userId, tagId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(deletedTagDb.Id.ToString(), result.Id);
			Assert.AreEqual(deletedTagDb.Name, result.Name);
		}

		[TestMethod]
		public void Delete_NonAdminUser_ThrowsUnauthorizedOperationException()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var tagToDelete = "TagToDelete";

			userRepositoryMock.Setup(repo => repo.GetById(userId))
				.Returns(new UserDb { IsAdmin = false, Username = "RegularUser" });

			// Act & Assert
			Assert.ThrowsException<UnauthorizedOperationException>(() => tagService.Delete(userId, tagToDelete));
		}
	}
}
