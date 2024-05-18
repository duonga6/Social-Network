namespace SocialNetwork.Business.DTOs.Responses
{
    public class StatsPostResponse
    {
        public int PostPerDay { set; get; }
        public int PostPerWeek { set; get; }
        public int PostPerMonth { set; get; }
        public int TotalPost { set; get; }
    }
}
