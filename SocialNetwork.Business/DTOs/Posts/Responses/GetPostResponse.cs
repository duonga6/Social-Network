namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetPostResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int Access { set; get; }
        public GetGroupBasicResponse Group { set; get; } = null!;
        public BasicUserResponse User { set; get; } = null!;
        public List<GetPostMediaResponse>? PostMedias { set; get; }
        public GetPostResponse? SharePost { set; get; }
    }
}
