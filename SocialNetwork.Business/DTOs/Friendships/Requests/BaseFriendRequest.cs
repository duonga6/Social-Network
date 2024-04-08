using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class BaseFriendRequest
    {
        [Required]
        public string TargetUserId { set; get; } = string.Empty;
    }
}
