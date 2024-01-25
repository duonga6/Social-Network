using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Utilities.Requests
{
    public class SendMailRequest
    {
        [Required]
        public string ToEmail { set; get; } = string.Empty;
        [Required]
        public string Subject { set; get; } = string.Empty;
        [Required]
        public string HtmlBody { set; get; } = string.Empty;
    }
}
