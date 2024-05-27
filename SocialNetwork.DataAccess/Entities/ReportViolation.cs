using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.DataAccess.Entities
{
    public class ReportViolation : BaseEntity<Guid>
    {
        public string UserId { set; get; }
        public string Content { set; get; }
        public string JsonDetails { set; get; }
        public bool IsSolved { set; get; }
        public string SolvedById { set; get; }
        public string RelatedId { set; get; }
        public ReportTypeEnum ReportType { set; get; }
        public DateTime SolvedAt { set; get; }

        public User User { set; get; }
        public User SolvedUser { set; get; }
        public ICollection<ActionReportDid> ActionReportDids { set; get; }
    }
}
