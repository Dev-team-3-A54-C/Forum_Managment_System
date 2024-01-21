using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
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
	public class Update_Should
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
			tagService = new TagService
				(tagRepositoryMock.Object, mapperMock.Object, userRepositoryMock.Object);
		}
		[TestMethod]
		public void Update_ValidAdminUserAndUniqueTagName_ReturnsTagResponseDTO()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var tagId = Guid.NewGuid();
			var tagDto = new TagDTO { Name = "UpdatedTag" };

		

			userRepositoryMock.Setup(repo => repo.GetById(userId))
				.Returns(new UserDb { IsAdmin = true, Username = "AdminUser" });

			var existingTagDb = new TagDb { Id = tagId, Name = "ExistingTag" };
			tagRepositoryMock.Setup(repo => repo.GetById(tagId)).ReturnsAsync(existingTagDb);

			var updatedTagDb = new TagDb { Id = tagId, Name = tagDto.Name };
			tagRepositoryMock.Setup(repo => repo.DoesNameExist(tagDto.Name)).ReturnsAsync(false);
			tagRepositoryMock.Setup(repo => repo.Update(It.IsAny<TagDb>())).ReturnsAsync(updatedTagDb);

			mapperMock.Setup(mapper => mapper.Map<TagDb>(It.IsAny<TagDTO>()))
				.Returns(new TagDb { Id = tagId, Name = tagDto.Name });
			mapperMock.Setup(mapper => mapper.Map<TagResponseDTO>(It.IsAny<TagDb>()))
				.Returns(new TagResponseDTO { Id = tagId.ToString(), Name = tagDto.Name });

			// Act
			var result = tagService.Update(userId, tagId, tagDto);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(updatedTagDb.Id.ToString(), result.Id);
			Assert.AreEqual(updatedTagDb.Name, result.Name);
		}

		[TestMethod]
		public void Update_NonAdminUser_ThrowsUnauthorizedOperationException()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var tagId = Guid.NewGuid();
			var tagDto = new TagDTO { Name = "UpdatedTag" };

			userRepositoryMock.Setup(repo => repo.GetById(userId))
				.Returns(new UserDb { IsAdmin = false, Username = "RegularUser" });

			// Act & Assert
			Assert.ThrowsException<UnauthorizedOperationException>(
				() => tagService.Update(userId, tagId, tagDto));
		}

		[TestMethod]
		public void Update_DuplicateTagName_ThrowsNameDuplicationException()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var tagId = Guid.NewGuid();
			var tagDto = new TagDTO { Name = "DuplicateTag" };

			userRepositoryMock.Setup(repo => repo.GetById(userId))
				.Returns(new UserDb { IsAdmin = true, Username = "AdminUser" });

			mapperMock.Setup(mapper => mapper.Map<TagDb>(It.IsAny<TagDTO>()))
				.Returns((TagDTO r) => new TagDb { Name = r.Name });

			var existingTagDb = new TagDb { Id = tagId, Name = "ExistingTag" };
			tagRepositoryMock.Setup(repo => repo.GetById(tagId)).ReturnsAsync(existingTagDb);

			tagRepositoryMock.Setup(repo => repo.DoesNameExist(tagDto.Name)).ReturnsAsync(true);

			// Act & Assert
			Assert.ThrowsException<NameDuplicationException>(() => tagService.Update(userId, tagId, tagDto));
		}
	}
}
