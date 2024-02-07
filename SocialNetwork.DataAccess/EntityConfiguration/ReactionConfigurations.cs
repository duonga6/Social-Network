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

            builder.Property(r => r.IconUrl)
                .IsRequired();

            var listData = new List<Reaction>
            {
                new() { 
                    Id = (int)ReactionEnum.Like,
                    Name = "Thích",
                    IconUrl = "https://i.ibb.co/BNNPTgp/like.png",
                    ColorCode = "#0561F2"
                },
                new() { 
                    Id = (int)ReactionEnum.Love,
                    Name = "Yêu thích",
                    IconUrl = "https://i.ibb.co/wJ8H9wy/love.png",
                    ColorCode = "#f33e58"
                },
                new() { 
                    Id = (int)ReactionEnum.Haha,
                    Name = "Haha",
                    IconUrl = "https://i.ibb.co/BKBGxqr/haha.png",
                    ColorCode = "#F7B125"
                },
                new() { 
                    Id = (int)ReactionEnum.Wow,
                    Name = "Wow",
                    IconUrl = "https://i.ibb.co/hX0ktCf/wow.png",
                    ColorCode = "#F7B125"
                },
                new() { 
                    Id = (int)ReactionEnum.Sad,
                    Name = "Buồn",
                    IconUrl = "https://i.ibb.co/9vgHgc4/sad.png",
                    ColorCode = "#F7B125"
                },
                new() { 
                    Id = (int)ReactionEnum.Angry,
                    Name = "Phẫn nộ",
                    IconUrl = "https://i.ibb.co/dp2vn3Z/angry.png",
                    ColorCode = "#E9710F"
                }
            };

            builder.HasData(listData);
        }
    }
}
