using AutoMapper;
using ForumManagmentSystem.Core.Helpers;
using ForumManagmentSystem.Core.ResponseDTOs;
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
	public class GetById_Should
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
		public void Return_TagResponse()
		{
			//Arrange
			TagDb expectedResponse = TestHelper.GetTestTag();

			var sut = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			tagRepositoryMock.Setup(repo => repo.GetById(expectedResponse.Id)).ReturnsAsync(expectedResponse);

			//Act
			TagResponseDTO actualResponse = sut.GetById(expectedResponse.Id);

			//Assert
			Assert.AreEqual(expectedResponse.Id, actualResponse.Id);
			Assert.AreEqual(expectedResponse.Name, actualResponse.Name);


		}
		[TestMethod]
		public void Throw_EntityNotFoundException_When_Not_Existent()
		{
			// Arrange
			var tagService = new TagService(tagRepositoryMock.Object, mapper.Object, usersRepositoryMock.Object);

			var nonExistentTagId = new Guid("999");
			tagRepositoryMock.Setup(repo => repo.GetById(nonExistentTagId)).ReturnsAsync((TagDb)null);

			// Act and Assert
			Assert.ThrowsException<EntityNotFoundException>(() => tagService.GetById(nonExistentTagId));
		}
	}
	
}
