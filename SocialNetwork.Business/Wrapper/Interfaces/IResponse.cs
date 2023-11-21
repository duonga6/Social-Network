namespace SocialNetwork.Business.Wrapper.Interfaces
{
    public interface IResponse
    {
        bool Success { get; }
        int StatusCode { get; }
    }
}
