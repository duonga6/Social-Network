using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class GroupInviteConfigurations : IEntityTypeConfiguration<GroupInvite>
    {
        public void Configure(EntityTypeBuilder<GroupInvite> builder)
        {
            builder.Property(x => x.AdminAccepted).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.GroupInvites)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.GroupInvitesCreate)
                .HasForeignKey(x => x.CreatedId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.Group)
                .WithMany(x => x.GroupInvites)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
