using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.User.Requests
{
    public class LoginRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;
    }
}
