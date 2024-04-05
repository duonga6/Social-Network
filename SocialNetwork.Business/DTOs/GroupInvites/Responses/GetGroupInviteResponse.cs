namespace SocialNetwork.Business.DTOs.GroupInvites.Responses
{
    public class GetGroupInviteResponse
    {
        public Guid Id { set; get; }
        public Guid GroupId { set; get; }
        public string UserId { set; get; } = string.Empty;
        public DateTime CreatedAt { set; get; }
        public DateTime UpdatedAt { set; get; }
    }
}
