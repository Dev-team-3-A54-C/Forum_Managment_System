using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Infrastructure.Exceptions
{
    public class CannotChangeUsernameException : Exception
    {
        public CannotChangeUsernameException(string message) : base(message) { }

    }
}
