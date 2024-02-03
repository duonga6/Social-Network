namespace SocialNetwork.Business.DTOs.Reaction.Response
{
    public class GetReactionResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string IconUrl { set; get; } = string.Empty;
        public string ColorCode { set; get; } = string.Empty;
    }
}
