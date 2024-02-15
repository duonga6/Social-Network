using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class UpdateReactionRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Code { get; set; }
    }
}
