namespace SocialNetwork.Business.Wrapper.Abstract
{
    public interface IResponse
    {
        bool Success { get; }
        int Status { get; }
    }
}
