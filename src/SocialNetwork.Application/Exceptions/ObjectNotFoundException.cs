namespace SocialNetwork.Application.Exceptions
{
    public class ObjectNotFoundException : ApplicationException
    {
        private static string ErrorMessage = "Object not found {0}.";

        public ObjectNotFoundException()
        {
        }

        public ObjectNotFoundException(string objName) : base(string.Format(ErrorMessage, objName))
        { }
    }
}
