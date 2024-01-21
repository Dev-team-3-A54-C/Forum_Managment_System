using AutoMapper;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Data.Models;
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
	public class GetAll_Should
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
		public void GetAll_ReturnsTagResponseDTOList()
		{
			// Arrange

			var tagDbList = new List<TagDb>
			{
				new TagDb { Id = Guid.NewGuid(), Name = "Tag1" },
				new TagDb { Id = Guid.NewGuid(), Name = "Tag2" },
				new TagDb { Id = Guid.NewGuid(), Name = "Tag3" }
			};

			tagRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(tagDbList);
			mapper.Setup(mapper => mapper.Map<TagResponseDTO>(It.IsAny<TagDb>()))
				.Returns((TagDb tagDb) => new TagResponseDTO { Id = tagDb.Id.ToString(), Name = tagDb.Name });

			// Act
			var result = tagService.GetAll();

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(tagDbList.Count, result.Count());
		}

	}
}
