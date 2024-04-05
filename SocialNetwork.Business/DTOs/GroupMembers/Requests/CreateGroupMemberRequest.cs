using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.GroupMembers.Requests
{
    public class CreateGroupMemberRequest
    {
        [Required]
        public Guid GroupId { set; get; }
    }
}
