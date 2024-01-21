using AutoMapper;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Core.Services.Contracts;
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
	public class Delete_Should
	{
		Mock<IUsersRepository> usersRepositoryMock;
		Mock<ITagRepository> tagRepositoryMock;
		Mock<IMapper> mapper;
		ITagService tagService;

		[TestInitialize]
		public void Init()
		{
			usersRepositoryMock = new Mock<IUsersRepository>();
			tagRepositoryMock = new Mock<ITagRepository>();
			mapper = new Mock<IMapper>();
			tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);
		}

		[TestMethod]
		public void Return_Deleted_Tag()
		{
			// Arrange
			var adminUser = new UserDb() { Id = new Guid(), Username = "Admin", IsAdmin = true };
			usersRepositoryMock.Setup(repo => repo.GetById(adminUser.Id)).Returns(adminUser);

			var tagIdToDelete = new Guid();
			var tagToDelete = new TagDb { Id = tagIdToDelete, Name = "ToDelete" };
			tagRepositoryMock.Setup(repo => repo.GetById(tagIdToDelete)).ReturnsAsync(tagToDelete);

			// Act
			var result = tagService.Delete(adminUser.Id, tagIdToDelete);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(tagToDelete, result);
		}
		[TestMethod]
		public void Throw_EntityNotFoundException_When_User_Not_Found()
		{
			// Arrange
			var nonExistentUserId = new Guid("userid");
			//usersRepositoryMock.Setup(repo => repo.GetById(nonExistentUserId)).Returns((UserDb)null);
			var tagIdToDelete = new Guid("tagid");

			// Act and Assert
			Assert.ThrowsException<EntityNotFoundException>(() =>
				tagService.Delete(nonExistentUserId, tagIdToDelete));
		}
		[TestMethod]
		public void Throw_UnauthorizedOperationException_When_User_Not_Authorized()
		{
			// Arrange
			var tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			var regularUser = new UserDb() { Username = "RegularUser", IsAdmin = false};
			usersRepositoryMock.Setup(repo => repo.GetById(regularUser.Id)).Returns(regularUser);

			var tagIdToDelete = new Guid("1");

			// Act and Assert
			Assert.ThrowsException<UnauthorizedOperationException>(() =>
				tagService.Delete(regularUser.Id, tagIdToDelete));
		}
		[TestMethod]
		public void Throw_EntityNotFoundException_When_Tag_Not_Found()
		{
			// Arrange
			var tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			var adminUser = new UserDb() { Username = "AdminUser", IsAdmin = true };
			usersRepositoryMock.Setup(repo => repo.GetById(adminUser.Id)).Returns(adminUser);

			var nonExistentTagId = new Guid();
			tagRepositoryMock.Setup(repo => repo.GetById(nonExistentTagId)).ReturnsAsync((TagDb)null);

			// Act and Assert
			Assert.ThrowsException<EntityNotFoundException>(() =>
				tagService.Delete(adminUser.Id, nonExistentTagId)
			);
		}
	}
}
