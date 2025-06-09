namespace SocialNetwork.Application.Wrappers.Responses
{
    public interface ICursorResponse<T> : IPagedResponse<T>
    {
        bool HasNextPage { get; }
    }
}
