using SocialNetwork.Business.Constants;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Wrapper
{
    public class DataResponse : IDataResponse
    {
        public object Data { get; }

        public string Message { get; }

        public bool Success { get; } = true;

        public int Status { get; }

        public DataResponse(object data, int statusCode)
        {
            Data = data;
            Message = Messages.GetSuccessfully;
            Status = statusCode;
        }

        public DataResponse(object data, int statusCode, string message)
        {
            Data = data;
            Message = message;
            Status = statusCode;
        }
    }
}
