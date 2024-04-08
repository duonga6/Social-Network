using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class ResetPasswordRequest
    {
        [Required]
        public string Email { set; get; } = string.Empty;
        [Required]
        public string Password { set; get; } = string.Empty;
        [Required]
        public string Code { set; get; } = string.Empty;
    }
}
