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
                    IconUrl = "https://ibb.co/QddcY6g",
                    ColorCode = "#0561F2"
                },
                new() { 
                    Id = (int)ReactionEnum.Love,
                    Name = "Yêu thích",
                    IconUrl = "https://ibb.co/vsf57Q1",
                    ColorCode = "#f33e58"
                },
                new() { 
                    Id = (int)ReactionEnum.Haha,
                    Name = "Haha",
                    IconUrl = "https://ibb.co/FqzXMg0",
                    ColorCode = "#F7B125"
                },
                new() { 
                    Id = (int)ReactionEnum.Wow,
                    Name = "Wow",
                    IconUrl = "https://ibb.co/mvpmMS8",
                    ColorCode = "#F7B125"
                },
                new() { 
                    Id = (int)ReactionEnum.Sad,
                    Name = "Buồn",
                    IconUrl = "https://ibb.co/W35v5Gz",
                    ColorCode = "#F7B125"
                },
                new() { 
                    Id = (int)ReactionEnum.Angry,
                    Name = "Phẫn nộ",
                    IconUrl = "https://ibb.co/FYw1Gfp",
                    ColorCode = "#E9710F"
                }
            };

            builder.HasData(listData);
        }
    }
}
