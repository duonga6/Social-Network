namespace SocialNetwork.Application.Wrappers.Responses
{
    public class CursorResponse<T> : ICursorResponse<T>
    {
        public bool HasNextPage { get; }

        public int TotalItems { get; }

        public ICollection<T> Data { get; }

        public bool IsSuccess { get; } = true;

        public CursorResponse(ICollection<T> data, int totalItems, bool hasNextPage)
        {
            Data = data;
            TotalItems = totalItems;
            HasNextPage = hasNextPage;
        }
    }
}
