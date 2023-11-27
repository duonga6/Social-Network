namespace SocialNetwork.Business.DTOs.PostImage.Responses
{
    public class GetPostImageResponse
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
