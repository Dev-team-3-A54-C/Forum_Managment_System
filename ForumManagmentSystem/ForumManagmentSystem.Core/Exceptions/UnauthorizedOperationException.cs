namespace ForumManagmentSystem.Core.Exceptions
{
    public class UnauthorizedOperationException : ApplicationException
    {
        public UnauthorizedOperationException(string message)
           : base(message)
        {
        }
    }
}
