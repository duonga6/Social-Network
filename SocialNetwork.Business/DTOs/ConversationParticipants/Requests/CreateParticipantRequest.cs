namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateParticipantRequest
    {
        public List<string> UserIds { set; get; } = null!;
    }
}
