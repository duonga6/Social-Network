﻿namespace SocialNetwork.DataAccess.Entities
{
    public class PostReaction : BaseEntity<Guid>
    {
        public int ReactionId { get; set; }
        public Reaction Reaction { get; set; }

        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
