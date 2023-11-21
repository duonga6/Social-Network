namespace SocialNetwork.Business.Wrapper.Interfaces
{
    public interface IDataResponse : IResponse
    {
        object Data { get; }
        string Message { get; }
    }
}
