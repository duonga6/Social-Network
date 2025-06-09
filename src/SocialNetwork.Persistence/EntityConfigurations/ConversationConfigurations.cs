using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Persistence.EntityConfigurations
{
    public class ConversationConfigurations : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.Image).IsRequired(false);

            builder.HasOne(x => x.CreatedUser)
                .WithMany(u => u.ConversationCreated)
                .HasForeignKey(x => x.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.CreatedDate).IsUnique(false);
        }
    }
}
