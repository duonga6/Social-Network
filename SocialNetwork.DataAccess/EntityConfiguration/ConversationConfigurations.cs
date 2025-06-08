using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class ConversationConfigurations : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.Image).IsRequired(false);

            builder.Property(x => x.Type).HasColumnType("int");

            builder.HasOne(x => x.CreatedBy)
                .WithMany(u => u.ConversationCreated)
                .HasForeignKey(x => x.CreatedId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.UpdatedAt).IsUnique(false);
        }
    }
}
