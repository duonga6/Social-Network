using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class StrangeMessageBlockConfigurations : IEntityTypeConfiguration<StrangeMessageBlock>
    {
        public void Configure(EntityTypeBuilder<StrangeMessageBlock> builder)
        {
            builder.HasOne(x => x.FromUser)
                .WithMany(u => u.StrangeMessageBlocked)
                .HasForeignKey(x => x.FromId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ToUser)
                .WithMany(u => u.StrangeMessageIsBlocked)
                .HasForeignKey(x => x.ToId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
