namespace SocialNetwork.Business.Wrapper.Interfaces
{
    internal interface IPagedResponse<T> : IResponse
    {
        T Data { get; }
    }
}
