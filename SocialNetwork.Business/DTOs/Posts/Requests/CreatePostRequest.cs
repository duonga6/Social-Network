namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreatePostRequest
    {
        public string Content { get; set; } = string.Empty;
        public ICollection<CreatePostMediaRequest> PostMedias { get; set; } = new List<CreatePostMediaRequest>();
    }
}
