namespace SocialNetwork.Business.Wrapper.Abstract
{
    public interface IDataResponse<T> : IResponse
    {
        T Data { get; }
        string Message { get; }
    }
}
