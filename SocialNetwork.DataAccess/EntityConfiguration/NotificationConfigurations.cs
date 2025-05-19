using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(x => x.ToId).IsRequired(false);

            builder.HasOne(n => n.ToUser)
                .WithMany(u => u.NotificationsReceive)
                .HasForeignKey(n => n.ToId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasOne(n => n.FromUser)
                .WithMany(u => u.NotificationSend)
                .HasForeignKey(n => n.FromId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasIndex(x => x.CreatedDate);
        }
    }
}
