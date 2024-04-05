using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Groups.Request
{
    public class CreateGroupRequest
    {
        [Required]
        public string Name { set; get; } = string.Empty;
        public string Description { set; get; } = string.Empty;
        public string CoverImage { set; get; } = string.Empty;
        [Required]
        public bool IsPublic { set; get; }
        
    }
}
