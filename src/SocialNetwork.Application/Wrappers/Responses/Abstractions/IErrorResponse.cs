namespace SocialNetwork.Application.Wrappers.Responses
{
    public interface IErrorResponse : IResponse
    {
        List<string> Errors { get; }
        string ErrorCode { get; }
    }
}
