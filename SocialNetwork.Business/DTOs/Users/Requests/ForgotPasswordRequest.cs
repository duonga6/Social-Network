using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Users.Requests
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { set; get; } = string.Empty;
    }
}
