using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Token.Requests
{
    public class RenewTokenRequest
    {
        [Required]
        public string AccessToken { get; set; } = string.Empty;
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
