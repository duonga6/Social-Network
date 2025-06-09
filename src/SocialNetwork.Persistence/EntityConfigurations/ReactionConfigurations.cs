using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Enums;

namespace SocialNetwork.Persistence.EntityConfigurations
{
    public class ReactionConfigurations : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.Property(r => r.Name)
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder.Property(r => r.IconUrl)
                .IsRequired();

            var listData = new List<Reaction>
            {
                new() { 
                    Id = (int)ReactionEnum.Like,
                    Name = ReactionEnum.Like.ToString(),
                    IconUrl = "https://i.ibb.co/BNNPTgp/like.png",
                    ColorCode = "#0561F2"
                },
                new() { 
                    Id = (int)ReactionEnum.Love,
                    Name = ReactionEnum.Love.ToString(),
                    IconUrl = "https://i.ibb.co/wJ8H9wy/love.png",
                    ColorCode = "#f33e58"
                },
                new() { 
                    Id = (int)ReactionEnum.Haha,
                    Name = ReactionEnum.Haha.ToString(),
                    IconUrl = "https://i.ibb.co/BKBGxqr/haha.png",
                    ColorCode = "#F7B125"
                },
                new() { 
                    Id = (int)ReactionEnum.Wow,
                    Name = ReactionEnum.Wow.ToString(),
                    IconUrl = "https://i.ibb.co/hX0ktCf/wow.png",
                    ColorCode = "#F7B125"
                },
                new() { 
                    Id = (int)ReactionEnum.Sad,
                    Name = ReactionEnum.Sad.ToString(),
                    IconUrl = "https://i.ibb.co/9vgHgc4/sad.png",
                    ColorCode = "#F7B125"
                },
                new() { 
                    Id = (int)ReactionEnum.Angry,
                    Name = ReactionEnum.Angry.ToString(),
                    IconUrl = "https://i.ibb.co/dp2vn3Z/angry.png",
                    ColorCode = "#E9710F"
                }
            };

            builder.HasData(listData);
        }
    }
}
