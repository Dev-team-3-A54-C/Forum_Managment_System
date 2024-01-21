using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
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
	public class Create_Should
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
		public void ValidUserAndUniqueTagName_ReturnsTagResponseDTO()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var tagDto = new TagDTO { Name = "NewTag" };

			userRepositoryMock.Setup(repo => repo.GetById(userId)).Returns(new UserDb { IsAdmin = true, Username = "AdminUser" });
			tagRepositoryMock.Setup(repo => repo.DoesNameExist(tagDto.Name)).ReturnsAsync(false);

			var createdTagDb = new TagDb { Id = Guid.NewGuid(), Name = tagDto.Name };
			tagRepositoryMock.Setup(repo => repo.Create(It.IsAny<TagDb>())).ReturnsAsync(createdTagDb);

			mapperMock.Setup(mapper => mapper.Map<TagResponseDTO>(It.IsAny<TagDb>()))
				.Returns(new TagResponseDTO { Id = createdTagDb.Id.ToString(), Name = createdTagDb.Name });

			// Act
			var result = tagService.Create(userId, tagDto);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(createdTagDb.Id.ToString(), result.Id);
			Assert.AreEqual(createdTagDb.Name, result.Name);
		}

		[TestMethod]
		public void NonAdminUser_ThrowsUnauthorizedOperationException()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var tagDto = new TagDTO { Name = "NewTag" };

			

			userRepositoryMock.Setup(repo => repo.GetById(userId)).Returns(new UserDb { IsAdmin = false, Username = "RegularUser" });

			// Act & Assert
			Assert.ThrowsException<UnauthorizedOperationException>(() => tagService.Create(userId, tagDto));
		}

		[TestMethod]
		public void DuplicateTagName_ThrowsNameDuplicationException()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var tagDto = new TagDTO { Name = "ExistingTag" };

			userRepositoryMock.Setup(repo => repo.GetById(userId)).Returns(new UserDb { IsAdmin = true, Username = "AdminUser" });
			tagRepositoryMock.Setup(repo => repo.DoesNameExist(tagDto.Name)).ReturnsAsync(true);

			// Act & Assert
			Assert.ThrowsException<NameDuplicationException>(() => tagService.Create(userId, tagDto));
		}
	}
}
