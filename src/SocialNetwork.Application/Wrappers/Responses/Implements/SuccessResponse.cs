namespace SocialNetwork.Application.Wrappers.Responses
{
    public class SuccessResponse : ISuccessResponse
    {
        public string Message { get; }

        public bool IsSuccess { get; } = true;

        public SuccessResponse(string message = "")
        {
            Message = message;
        }
    }
}
