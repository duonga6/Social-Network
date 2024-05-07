using SocialNetwork.Business.Utilities.Validation;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateMessageRequest
    {
        [Required]
        public string UserId { set; get; } = string.Empty;
        [NotEmptyOrWhiteSpace]
        public string Content { get; set; } = string.Empty;
    }
}