namespace SocialNetwork.Business.Wrapper.Interfaces
{
    public interface IErrorResponse : IResponse
    {
        List<string> Errors { get; }
    }
}
