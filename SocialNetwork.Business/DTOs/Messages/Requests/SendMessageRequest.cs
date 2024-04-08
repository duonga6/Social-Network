using SocialNetwork.DataAccess.Utilities.Enum;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class SendMessageRequest
    {
        [Required]
        public string ReceiverId { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public MessageEnum MessageType { get; set; }
    }
}
