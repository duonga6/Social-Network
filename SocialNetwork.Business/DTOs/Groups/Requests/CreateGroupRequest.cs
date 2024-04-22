using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateGroupRequest
    {
        [Required]
        public string Name { set; get; } = string.Empty;
        public string? Description { set; get; }
        public string? CoverImage { set; get; }
        [Required]
        public bool IsPublic { set; get; }
        [Required]
        public bool PreCensored { set; get; }
        
    }
}
