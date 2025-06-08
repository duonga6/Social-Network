namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetReportActionDidResponse
    {
        public Guid Id { set; get; }
        public Guid ReportId { set; get; }
        public int ActionReportId { set; get; }
        public BasicUserResponse CreatedBy { set; get; } = null!;
        public DateTime CreatedAt { set; get; }
    }
}
