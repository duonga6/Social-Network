namespace SocialNetwork.Application.Wrappers.Responses
{
    public class PagedResponse<T> : IPagedResponse<T>
    {
        public int TotalItems { get; }

        public ICollection<T> Data { get; }

        public bool IsSuccess { get; } = true;

        public PagedResponse(ICollection<T> data, int totalItems)
        {
            Data = data;
            TotalItems = totalItems;
        }
    }
}
