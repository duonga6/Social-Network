using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Wrapper
{
    public class SuccessResponse : ISuccessResponse
    {
        public string Message { get; }
        public bool Success { get; } = true;
        public int StatusCode { get; }

        public SuccessResponse(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}
