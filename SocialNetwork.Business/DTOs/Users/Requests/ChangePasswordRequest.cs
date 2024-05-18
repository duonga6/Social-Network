using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class ChangePasswordRequest
    {
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(8)]
        public string OldPassword { get; set; } = string.Empty;
        [MinLength(8)]
        [Required]
        public string NewPassword { get; set; } = string.Empty;
    }
}
