using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class ReportViolationConfigurations : IEntityTypeConfiguration<ReportViolation>
    {
        public void Configure(EntityTypeBuilder<ReportViolation> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(d => d.ReportsSend)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SolvedUser)
                .WithMany(d => d.ReportsSolved)
                .HasForeignKey(x => x.SolvedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Content).IsRequired();
        }
    }
}
