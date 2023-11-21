using SocialNetwork.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    internal class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(p => p.FirstName)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnType("nvarchar(50)")
                .IsRequired();
        }
    }
}
