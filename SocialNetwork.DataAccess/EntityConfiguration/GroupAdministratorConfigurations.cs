using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class GroupAdministratorConfigurations : IEntityTypeConfiguration<GroupAdministrator>
    {
        public void Configure(EntityTypeBuilder<GroupAdministrator> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.GroupAdministrators)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.Group)
                .WithMany(x => x.GroupAdministrators)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
