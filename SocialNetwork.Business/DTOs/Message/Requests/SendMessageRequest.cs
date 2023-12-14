using SocialNetwork.DataAccess.Utilities.Enum;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Message.Requests
{
    public class SendMessageRequest
    {
        [Required]
        public string ReceiverId { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public MessageType MessageType { get; set; }
    }
}
