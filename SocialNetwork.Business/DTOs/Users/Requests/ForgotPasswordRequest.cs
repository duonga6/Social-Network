using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { set; get; } = string.Empty;
    }
}
