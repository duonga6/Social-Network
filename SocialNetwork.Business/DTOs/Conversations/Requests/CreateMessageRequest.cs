using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateMessageOnConversationRequest
    {
        [Required]
        public string Content { set; get; } = string.Empty;
    }
}
