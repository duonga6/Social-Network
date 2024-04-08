using SocialNetwork.Business.Constants;
using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.Business.Wrapper
{
    public class CursorResponse<T> : IPagedResponse<T>
    {
        public T Data { get; }
        public object? EndCursor { get; }
        public bool HasNextPage { get; }
        public int TotalItems { set; get; }

        public bool Success { get; } = true;

        public int Status { get; }

        public string Message { set; get; }

        public CursorResponse(T data, object? endCursor, bool hasNextPage, int totalItems , string message, int status)
        {
            Data = data;
            Message = message;
            Status = status;
            EndCursor = endCursor;
            HasNextPage = hasNextPage;
            TotalItems = totalItems;
        }

        public CursorResponse(T data, object? endCursor, bool hasNextPage, int totalItems)
        {
            Data = data;
            EndCursor = endCursor;
            HasNextPage = hasNextPage;
            Status = 200;
            Message = Messages.GetSuccessfully;
            TotalItems = totalItems;
        }
    }
}
