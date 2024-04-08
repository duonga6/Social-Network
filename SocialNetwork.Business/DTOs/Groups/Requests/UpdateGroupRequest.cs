using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class UpdateGroupRequest
    {
        [Required]
        public string Name { set; get; } = string.Empty;
        public string Description { set; get; } = string.Empty;
        [Required]
        public bool IsPrivate { get; set; }
    }
}
