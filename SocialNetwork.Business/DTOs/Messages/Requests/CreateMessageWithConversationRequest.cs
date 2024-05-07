using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateMessageWithConversationRequest
    {
        [Required]
        public Guid ConversationId { set; get; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public Guid? ReplyId { set; get; }
    }
}