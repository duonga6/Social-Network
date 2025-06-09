namespace SocialNetwork.Application.Wrappers.Responses
{
    public interface ISuccessResponse : IResponse
    {
        string Message { get; }
    }
}
