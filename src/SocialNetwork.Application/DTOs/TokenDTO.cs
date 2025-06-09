namespace SocialNetwork.Application.DTOs
{
    public class TokenDTO
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTimeOffset AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTimeOffset RefreshTokenExpiration { get; set; }
    }
}
