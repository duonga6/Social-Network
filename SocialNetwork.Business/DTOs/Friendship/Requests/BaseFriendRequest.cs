using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Friendship.Requests
{
    public class BaseFriendRequest
    {
        [Required]
        public string TargetUserId { set; get; } = string.Empty;
    }
}
