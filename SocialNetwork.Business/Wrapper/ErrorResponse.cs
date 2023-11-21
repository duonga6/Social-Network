using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Wrapper
{
    public class ErrorResponse : IErrorResponse
    {
        public bool Success { get; } = false;
        public List<string> Errors { get; } = new();
        public int StatusCode { get; }

        public ErrorResponse(int StatusCode, string Error)
        {
            this.StatusCode = StatusCode;
            Errors.Add(Error);
        }

        public ErrorResponse(int StatusCode, List<string> Error)
        {
            this.StatusCode = StatusCode;
            Errors = Error;
        }

    }
}
