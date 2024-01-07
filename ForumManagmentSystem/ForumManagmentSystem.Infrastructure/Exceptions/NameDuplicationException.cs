using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Infrastructure.Exceptions
{
    public class NameDuplicationException : ApplicationException
    {
        public NameDuplicationException(string message) : base(message) { }        
            
    }
}
