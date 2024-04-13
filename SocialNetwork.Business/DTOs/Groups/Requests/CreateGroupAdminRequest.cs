using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateGroupAdminRequest
    {
        [Required]
        public string UserId { set; get; } = string.Empty;
        [Required]
        public Guid GroupId { set; get; }
    }
}
