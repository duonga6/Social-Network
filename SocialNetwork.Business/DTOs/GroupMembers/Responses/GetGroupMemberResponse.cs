namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetGroupMemberResponse
    {
        public Guid Id { set; get; }
        public Guid GroupId { set; get; }
        public bool IsAdmin { set; get; }
        public bool IsSuperAdmin { set; get; }
        public DateTime JoinedAt { set; get; }
        public BasicUserResponse User { set; get; } = null!;
    }
}
