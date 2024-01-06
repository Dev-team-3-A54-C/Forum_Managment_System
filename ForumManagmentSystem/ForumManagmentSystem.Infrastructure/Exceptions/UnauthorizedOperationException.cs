namespace ForumManagmentSystem.Infrastructure.Exceptions
{
    public class UnauthorizedOperationException : ApplicationException
    {
        public UnauthorizedOperationException(string message)
           : base(message)
        {
        }
    }
}
