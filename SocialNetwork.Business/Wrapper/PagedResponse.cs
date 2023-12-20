using SocialNetwork.Business.Constants;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Wrapper
{
    public class PagedResponse<T> : IPagedResponse<T>
    {
        public bool Success { get; } = true;

        public int Status { get; }

        public int TotalItems { get; }

        public T Data { get; }

        public string Message { get; }

        public PagedResponse(T data, int totalItems, int status)
        {
            Status = status;
            TotalItems = totalItems;
            Data = data;
            Message = Messages.GetSuccessfully;
        }

        public PagedResponse(T data, int totalItems, int status, string message)
        {
            Status = status;
            TotalItems = totalItems;
            Data = data;
            Message = message;
        }
    }
}
