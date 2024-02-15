using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Users.Requests
{
    /// <summary>
    /// Login model
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Email address
        /// </summary>
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
