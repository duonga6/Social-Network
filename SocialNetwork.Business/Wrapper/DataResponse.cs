using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Wrapper
{
    public class DataResponse : IDataResponse
    {
        public object Data { get; }

        public string Message { get; }

        public bool Success { get; } = true;

        public int StatusCode { get; }

        public DataResponse(object data, int statusCode)
        {
            Data = data;
            Message = "Get data successfully";
            StatusCode = statusCode;
        }

        public DataResponse(object data, int statusCode, string message)
        {
            Data = data;
            Message = message;
            StatusCode = statusCode;
        }
    }
}
