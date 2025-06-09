namespace SocialNetwork.Domain.Entities;

public class ReportAction : EntityBase<int>
{
    public string ActionName { set; get; }
    public ReportType ReportType { set; get; }

    public ICollection<ActionReportDid> ActionReportDids { set; get; }
}
