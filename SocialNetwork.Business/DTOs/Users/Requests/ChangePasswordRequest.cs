using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Users.Requests
{
    public class ChangePasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        public string OldPassword { get; set; } = string.Empty;
        [MinLength(8)]
        [Required]
        public string NewPassword { get; set; } = string.Empty;
    }
}
