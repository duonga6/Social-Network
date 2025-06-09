namespace SocialNetwork.Application.Wrappers.Responses
{
    public interface IDataResponse<T> : IResponse
    {
        T Data { get; }
    }
}
