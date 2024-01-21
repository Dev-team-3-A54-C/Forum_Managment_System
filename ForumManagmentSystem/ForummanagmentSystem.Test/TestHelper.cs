

using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForummanagmentSystem.Test
{
    internal class TestHelper
    {
        internal static UserDTO GetTestUser()
        {
            return new UserDTO()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Username = "Tester",
                Email = "test@mail.com",
                Password = "password",
                PhoneNumber = "1234567890"
            };
        }
        internal static TagDb GetTestTag()
        {
            return new TagDb()
            {
                Id = new Guid("1234"),
                Name = "MountainTestTag"
            };
        }
        internal static IEnumerable<TagDb> GetAllTestTags()
        {
            return new List<TagDb>()
            {
                new TagDb()
                {
                    Id = new Guid("1"),
                    Name = "TestName"
                },
                new TagDb()
                {
                    Id= new Guid("2"),
                    Name = "TestName2"
                },
                new TagDb()
                {
                    Id = new Guid("3"),
                    Name = "TestName3"
                }
            };
        }
        internal static TagDTO GetTestTagDTO()
        {
            return new TagDTO()
            {
                Name = "TagTest"
            };
        }
    }
}
