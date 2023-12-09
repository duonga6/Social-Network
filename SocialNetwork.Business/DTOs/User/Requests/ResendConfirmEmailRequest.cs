using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.User.Requests
{
    public class ResendConfirmEmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }  = string.Empty;
    }
}
