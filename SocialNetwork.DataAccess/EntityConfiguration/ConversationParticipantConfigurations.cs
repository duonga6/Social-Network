﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class ConversationParticipantConfigurations : IEntityTypeConfiguration<ConversationParticipant>
    {
        public void Configure(EntityTypeBuilder<ConversationParticipant> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(u => u.ConversationParticipants)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Conversation)
                .WithMany(c => c.ConversationParticipants)
                .HasForeignKey(x => x.ConversationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
