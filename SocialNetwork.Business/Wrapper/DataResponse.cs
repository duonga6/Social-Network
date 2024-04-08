using SocialNetwork.Business.Constants;
using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.Business.Wrapper
{
    public class DataResponse<T> : IDataResponse<T>
    {
        public T Data { get; }

        public string Message { get; }

        public bool Success { get; } = true;

        public int Status { get; }

        public DataResponse(T data, int statusCode)
        {
            Data = data;
            Message = Messages.GetSuccessfully;
            Status = statusCode;
        }

        public DataResponse(T data, int statusCode, string message)
        {
            Data = data;
            Message = message;
            Status = statusCode;
        }
    }
}
