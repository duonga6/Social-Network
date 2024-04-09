namespace SocialNetwork.Business.Wrapper.Abstract
{
    public interface IErrorResponse : IResponse
    {
        List<string> Errors { get; }
    }
}
