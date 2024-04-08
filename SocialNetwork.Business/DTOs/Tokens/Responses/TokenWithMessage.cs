namespace SocialNetwork.Business.DTOs.Responses
{
    public class TokenWithMessage
    {
        public string Message { get; set; } = string.Empty;
        public Token? Token { get; set; }
    }
}
