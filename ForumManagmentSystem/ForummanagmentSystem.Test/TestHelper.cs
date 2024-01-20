

using ForumManagmentSystem.Core.RequestDTOs;

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
    }
}
