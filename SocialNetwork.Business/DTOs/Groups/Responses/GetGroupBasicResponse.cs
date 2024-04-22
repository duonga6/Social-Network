namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetGroupBasicResponse
    {
        public Guid? Id { set; get; }
        public string Name { set; get; } = string.Empty;
        public string CoverImage { set; get; } = string.Empty;
    }
}
