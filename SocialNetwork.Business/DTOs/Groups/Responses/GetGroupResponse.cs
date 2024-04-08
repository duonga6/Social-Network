namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetGroupResponse
    {
        public Guid Id { set; get; }
        public string Name { set; get; } = string.Empty;
        public string Description { set; get; } = string.Empty;
        public bool IsPublic { set; get; }
        public int TotalMember { set; get; }
    }
}
