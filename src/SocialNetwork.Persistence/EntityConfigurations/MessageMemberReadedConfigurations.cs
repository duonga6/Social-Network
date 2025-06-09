using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Persistence.EntityConfigurations
{
    public class MessageMemberReadedConfigurations : IEntityTypeConfiguration<MessageMemberReaded>
    {
        public void Configure(EntityTypeBuilder<MessageMemberReaded> builder)
        {
            builder.HasOne(x => x.Message)
                .WithMany(mr => mr.MessageReadeds)
                .HasForeignKey(x => x.MessageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User)
                .WithMany(u => u.MessageReadeds)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Conversation)
                .WithMany(c => c.MessageReadeds)
                .HasForeignKey(x => x.ConversationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
