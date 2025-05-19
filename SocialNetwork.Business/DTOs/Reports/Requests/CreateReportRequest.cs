using SocialNetwork.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateReportRequest
    {
        [Required]
        public ReportTypeEnum ReportType { set; get; }
        [Required]
        public string RelationId { set; get; } = string.Empty;
        [Required]
        public string Content { set; get; } = string.Empty;
    }
}
