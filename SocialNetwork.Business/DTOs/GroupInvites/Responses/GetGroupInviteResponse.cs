namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetGroupInviteResponse
    {
        public Guid Id { set; get; }
        public Guid GroupId { set; get; }
        public BasicUserResponse User { set; get; } = null!;
        public bool AdminAccepted { set; get; }
        public bool UserAccepted { set; get; }
        public DateTime CreatedAt { set; get; }
    }
}
