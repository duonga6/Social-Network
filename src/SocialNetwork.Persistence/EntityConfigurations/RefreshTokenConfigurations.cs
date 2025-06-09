using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Persistence.EntityConfigurations
{
    public class RefreshTokenConfigurations : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.Property(r => r.UserId)
                .HasColumnType("nvarchar(450)")
                .IsRequired();

            builder.Property(r => r.Token)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.JwtId)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.IsUsed)
                .IsRequired();

            builder.Property(r => r.IsRevoked)
                .IsRequired();

            builder.Property(r => r.CreatedDate)
                .IsRequired();

            builder.Property(r => r.ExpiredAt)
                .IsRequired();

            builder.HasOne(r => r.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
