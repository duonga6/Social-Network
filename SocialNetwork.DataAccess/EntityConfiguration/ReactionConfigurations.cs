using SocialNetwork.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class ReactionConfigurations : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.Property(r => r.Name)
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            var listData = new List<Reaction>
            {
                new() { Id = (int)ReactionEnum.Like, Name = "Like"},
                new() { Id = (int)ReactionEnum.Love, Name = "Love"},
                new() { Id = (int)ReactionEnum.Haha, Name = "Haha"},
                new() { Id = (int)ReactionEnum.Wow, Name = "Wow"},
                new() { Id = (int)ReactionEnum.Sad, Name = "Sad"},
                new() { Id = (int)ReactionEnum.Angry, Name = "Angry"}
            };

            builder.HasData(listData);
        }
    }
}
