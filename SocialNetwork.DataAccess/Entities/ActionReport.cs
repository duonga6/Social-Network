using SocialNetwork.DataAccess.Enums;

namespace SocialNetwork.DataAccess.Entities
{
    public class ActionReport : EntityTrackingBase<int>
    {
        public string ActionName { set; get; }
        public ReportTypeEnum ReportType { set; get; }

        public ICollection<ActionReportDid> ActionReportDids { set; get; }
    }
}
