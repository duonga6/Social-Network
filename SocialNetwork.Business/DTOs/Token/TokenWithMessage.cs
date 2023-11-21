namespace SocialNetwork.Business.DTOs.Token
{
    public class TokenWithMessage
    {
        public string Message { get; set; } = string.Empty;
        public Token? Token { get; set; }
    }
}
