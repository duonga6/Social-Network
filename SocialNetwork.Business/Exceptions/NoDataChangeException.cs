namespace SocialNetwork.Business.Exceptions
{
    public class NoDataChangeException : Exception
    {
        public NoDataChangeException() : base("No records were changed") { }
    }
}
