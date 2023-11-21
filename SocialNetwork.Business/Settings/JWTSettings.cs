namespace SocialNetwork.Business.Settings
{
    public class JWTSettings
    {
        public string Audience { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public int AccessTokenExpiration { set; get; }
        public int RefreshTokenExpiration { set; get; }
        public string SecurityKey { get; set; } = string.Empty;
    }
}
