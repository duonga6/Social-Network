namespace SocialNetwork.Application.Wrappers.Responses
{
    public class ErrorResponse : IErrorResponse
    {
        public List<string> Errors { get; }

        public bool IsSuccess { get; } = false;

        public string ErrorCode { get; }

        public ErrorResponse(List<string> errors, string errorCode = "")
        {
            ErrorCode = errorCode;
            Errors = errors;
        }

        public ErrorResponse(string error, string errorCode = "")
        {
            Errors = [error];
            ErrorCode = errorCode;
        }
    }
}
