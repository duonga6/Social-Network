namespace SocialNetwork.Business.Wrapper.Abstract
{
    internal interface IPagedResponse<T> : IResponse
    {
        T Data { get; }
    }
}
