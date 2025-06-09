using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialNetwork.Persistence.EntityConfigurations
{
    public class ActionReportDidConfigurations : IEntityTypeConfiguration<ActionReportDid>
    {
        public void Configure(EntityTypeBuilder<ActionReportDid> builder)
        {
            builder.HasOne(x => x.ActionReport)
                .WithMany(d => d.ActionReportDids)
                .HasForeignKey(x => x.ActionReportId);

            builder.HasOne(x => x.Report)
                .WithMany(d => d.ActionReportDids)
                .HasForeignKey(x => x.ReportId);

            builder.HasOne(x => x.CreatedUser)
                .WithMany(d => d.ActionReportsDids)
                .HasForeignKey(x => x.CreatedBy);
        }
    }
}
