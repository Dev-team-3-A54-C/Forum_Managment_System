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
	public class Update_Should
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
		public void Return_Updated_Tag()
		{
			// Arrange
			var tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			var adminUser = new UserDb() { Username = "Admin", IsAdmin = true };
			usersRepositoryMock.Setup(repo => repo.GetById(adminUser.Id)).Returns(adminUser);

			var tagIdToUpdate = new Guid("1");
			var existingTag = new TagDb { Id = tagIdToUpdate, Name = "ToBeUpdated" };
			var updatedTag = new TagDb { Id = tagIdToUpdate, Name = "Updated" };

			tagRepositoryMock.Setup(repo => repo.GetById(tagIdToUpdate)).ReturnsAsync(existingTag);
			tagRepositoryMock.Setup(repo => repo.DoesNameExist(updatedTag.Name)).ReturnsAsync(false);
			tagRepositoryMock.Setup(repo => repo.Update(existingTag)).ReturnsAsync(updatedTag);

			// Act
			TagDTO updatedTagDTO = new TagDTO()
			{
				Name = updatedTag.Name
			};
			var result = tagService.Update(adminUser.Id, tagIdToUpdate, updatedTagDTO);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(updatedTag, result);
		}
		[TestMethod]
		public void Throw_EntityNotFoundException_When_User_Not_Found()
		{
			// Arrange
			var tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			var nonExistentUserId = new Guid("999");
			
			usersRepositoryMock.Setup(repo => repo.GetById(nonExistentUserId)).Returns((UserDb)null);
			
			var tagIdToUpdate = new Guid("1");
			TagDb testTag = TestHelper.GetTestTag();
			tagRepositoryMock.Setup(repo => repo.GetById(tagIdToUpdate)).ReturnsAsync(testTag);
			var updatedTagName = "Updated";

			// Act and Assert

			Assert.ThrowsException<EntityNotFoundException>(() =>
				tagService.Update(nonExistentUserId, tagIdToUpdate, TestHelper.GetTestTagDTO()));
		}
		[TestMethod]
		public void Throw_UnauthorizedOperationException_When_User_Not_Unthorized()
		{
			// Arrange
			var tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			var regularUser = new UserDb() { Username = "RegularUser", IsAdmin = false};
			usersRepositoryMock.Setup(repo => repo.GetById(regularUser.Id)).Returns(regularUser);

			var tagIdToUpdate = new Guid("1");
			var updatedTag = TestHelper.GetTestTagDTO();

			// Act and Assert
			Assert.ThrowsException<UnauthorizedOperationException>(() =>
				tagService.Update(regularUser.Id, tagIdToUpdate, updatedTag));
		}
		[TestMethod]
		public void Throw_NameDuplicationException_When_TagName_Exists()
		{
			// Arrange
			var tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			var adminUser = new UserDb() { Username = "Admin", IsAdmin = true };
			usersRepositoryMock.Setup(repo => repo.GetById(adminUser.Id)).Returns(adminUser);

			var tagIdToUpdate = new Guid("1");
			var existingTag = new TagDb(){ Id = tagIdToUpdate, Name = "ExistingTag" };
			var updatedTagName = "NewTag";

			tagRepositoryMock.Setup(repo => repo.GetById(tagIdToUpdate)).ReturnsAsync(existingTag);
			tagRepositoryMock.Setup(repo => repo.DoesNameExist(updatedTagName)).ReturnsAsync(true);

			// Act and Assert
			Assert.ThrowsException<NameDuplicationException>(() =>
				tagService.Update(adminUser.Id, tagIdToUpdate, TestHelper.GetTestTagDTO()));
		}
		[TestMethod]
		public void Throw_EntityNotFoundException_When_Tag_Not_Found()
		{
			// Arrange
			var tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			var adminUser = new UserDb() { Username = "Admin", IsAdmin = true};
			usersRepositoryMock.Setup(repo => repo.GetById(adminUser.Id)).Returns(adminUser);

			var nonExistentTagId = new Guid("999");
			var updatedTagName = "Updated";

			tagRepositoryMock.Setup(repo => repo.GetById(nonExistentTagId)).ReturnsAsync((TagDb)null);

			// Act and Assert
			Assert.ThrowsException<EntityNotFoundException>(() =>
				tagService.Update(adminUser.Id, nonExistentTagId, TestHelper.GetTestTagDTO()));
		}
	}
}
