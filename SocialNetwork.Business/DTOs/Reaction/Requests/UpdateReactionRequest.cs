using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Reaction.Requests
{
    public class UpdateReactionRequest
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Code { get; set; }
    }
}
