namespace SocialNetwork.Application.Wrappers.Responses
{
    public interface IPagedResponse<T> : IResponse 
    {
        int TotalItems { get; }
        ICollection<T> Data { get; }
    }
}
