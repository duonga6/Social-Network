namespace SocialNetwork.Business.DTOs.Reaction.Response
{
    public class GetReactionReponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Code { get; set; }
    }
}
