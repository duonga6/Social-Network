using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetReportActionResponse
    {
        public ReportActionId Id { set; get; }
        public string ActionName { set; get; } = string.Empty;
        public ReportTypeEnum ReportType { set; get; }
        public GetReportActionDidResponse ActionReportDid { set; get; } = null!;
    }
}
