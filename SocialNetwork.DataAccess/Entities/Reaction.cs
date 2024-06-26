﻿namespace SocialNetwork.DataAccess.Entities
{
    public class Reaction : BaseEntity<int>
    {
        public string Name { get; set; }
        public string IconUrl { set; get; }
        public string ColorCode { set; get; }

        public virtual ICollection<PostReaction> PostReactions { get; set; }
        public virtual ICollection<CommentReaction> CommentReactions { get; set; }
    }
}
