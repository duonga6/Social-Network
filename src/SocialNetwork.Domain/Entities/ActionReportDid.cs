namespace SocialNetwork.Domain.Entities;

public class ActionReportDid : EntityTrackingBase<Guid>
{
    public Guid ReportId { set; get; }
    public int ActionReportId { set; get; }


    public ReportViolation Report { set; get; }
    public ReportAction ActionReport { set; get; }
    public User CreatedUser { set; get; }
}
