using SocialNetwork.DataAccess.Enums;

namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetReportResponse
    {
        public Guid Id { set; get; }
        public string Content { set; get; } = string.Empty;
        public string JsonDetails { set; get; } = string.Empty;
        public bool IsSolved { set; get; }
        public string RelatedId { set; get; } = string.Empty;
        public ReportTypeEnum ReportType { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime SolvedAt { set; get; }

        public BasicUserResponse User { set; get; } = null!;
        public BasicUserResponse SolvedUser { set; get; } = null!;
    }
}
