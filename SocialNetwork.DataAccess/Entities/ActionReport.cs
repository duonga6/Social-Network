using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.DataAccess.Entities
{
    public class ActionReport : BaseEntity<int>
    {
        public string ActionName { set; get; }
        public ReportTypeEnum ReportType { set; get; }

        public ICollection<ActionReportDid> ActionReportDids { set; get; }
    }
}
