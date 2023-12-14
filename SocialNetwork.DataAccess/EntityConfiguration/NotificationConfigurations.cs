using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(n => n.Content)
                .IsRequired();

            builder.HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
