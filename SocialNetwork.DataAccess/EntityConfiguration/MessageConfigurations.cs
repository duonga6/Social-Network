using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    internal class MessageConfigurations : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(x => x.MessageType).HasColumnType("int");

            builder.HasIndex(x => x.CreatedDate).IsUnique(false);
            builder.HasIndex(x => x.ParticipantId).IsUnique(false);

            builder.HasOne(x => x.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Conversation)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.ConversationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ReplyMessage)
                .WithOne()
                .HasForeignKey<Message>(x => x.ReplyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Participant)
                .WithOne()
                .HasForeignKey<Message>(x => x.ParticipantId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
