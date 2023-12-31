﻿namespace SocialNetwork.DataAccess.Entities
{
    public class CommentReaction
    {
        public int ReactionId { get; set; }
        public Reaction Reaction { get; set; }

        public Guid CommentId { get; set; }
        public virtual PostComment Comment { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
