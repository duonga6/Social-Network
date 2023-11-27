using SocialNetwork.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class ReactionConfigurations : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.Property(r => r.Name)
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder.HasIndex(r => r.Name)
                .IsUnique();

            builder.ToTable("Reactions");
        }
    }
}
