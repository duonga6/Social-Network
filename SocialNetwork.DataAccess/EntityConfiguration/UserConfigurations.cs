using SocialNetwork.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    internal class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(p => p.FirstName)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.HasOne(x => x.Gender_FK)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.Gender)
                .IsRequired();
        }
    }
}
