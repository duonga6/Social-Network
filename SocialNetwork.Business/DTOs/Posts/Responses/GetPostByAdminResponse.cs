namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetPostByAdminResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int Access { set; get; }
        public int TotalComment { set; get; }
        public int TotalReaction { set; get; }
        public GetGroupBasicResponse? Group { set; get; } = null!;
        public BasicUserResponse User { set; get; } = null!;
    }
}
