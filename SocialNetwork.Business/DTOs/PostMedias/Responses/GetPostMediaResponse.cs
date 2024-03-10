namespace SocialNetwork.Business.DTOs.PostMedia.Responses
{
    public class GetPostMediaResponse
    {
        public Guid Id { get; set; }
        public string Title { set; get; } = string.Empty;
        public int MediaTypeId { set; get; }
        public string Url { get; set; } = string.Empty;
        public Guid PostId { set; get; }
        public DateTime CreatedAt { get; set; }
    }
}
