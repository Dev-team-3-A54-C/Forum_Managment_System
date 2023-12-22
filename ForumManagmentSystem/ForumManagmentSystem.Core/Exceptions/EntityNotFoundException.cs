namespace ForumManagmentSystem.Core.Exceptions
{
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string message)
            : base(message)
        {

        }
    }
}
