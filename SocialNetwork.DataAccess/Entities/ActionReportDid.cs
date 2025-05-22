namespace SocialNetwork.DataAccess.Entities
{
    public class ActionReportDid : EntityTrackingBase<Guid>
    {
        public Guid ReportId { set; get; }
        public int ActionReportId { set; get; }
        public string CreatedById { set; get; }


        public ReportViolation Report { set; get; }
        public ActionReport ActionReport { set; get; }
        public User CreatedUser { set; get; }
    }
}
