using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class ActionReportConfigurations : IEntityTypeConfiguration<ActionReport>
    {
        public void Configure(EntityTypeBuilder<ActionReport> builder)
        {

            builder.HasData(new List<ActionReport>
            {
                new()
                {
                    Id = (int)ReportActionId.REPORT_USER_LOCK_USER,
                    ActionName = "Khóa tài khoản người dùng",
                    ReportType = ReportTypeEnum.USER
                },
                new()
                {
                    Id = (int)ReportActionId.REPORT_POST_LOCK_USER,
                    ActionName = "Khóa tài khoản người dùng",
                    ReportType = ReportTypeEnum.POST
                },
                new()
                {
                    Id = (int)ReportActionId.REPORT_POST_DELETE_POST,
                    ActionName = "Xóa bài viết",
                    ReportType = ReportTypeEnum.POST
                },
                new()
                {
                    Id = (int)ReportActionId.REPORT_GROUP_LOCK_USER,
                    ActionName = "Khóa tài khoản người dùng",
                    ReportType = ReportTypeEnum.GROUP
                },
                new()
                {
                    Id = (int)ReportActionId.REPORT_GROUP_DELETE_GROUP,
                    ActionName = "Xóa nhóm",
                    ReportType = ReportTypeEnum.GROUP
                },
                new()
                {
                    Id = (int)ReportActionId.REPORT_COMMENT_DELETE_COMMENT,
                    ActionName = "Xóa bình luận",
                    ReportType = ReportTypeEnum.COMMENT
                },
                new()
                {
                    Id = (int)ReportActionId.REPORT_COMMENT_DELETE_USER,
                    ActionName = "Khóa tài khoản người dùng",
                    ReportType = ReportTypeEnum.COMMENT
                }
            });
        }
    }
}
