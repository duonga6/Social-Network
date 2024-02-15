using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateReactionRequest
    {
        [Required]
        public string Name { get; set; } = null!;
        public int Code { get; set; }
        
    }
}
