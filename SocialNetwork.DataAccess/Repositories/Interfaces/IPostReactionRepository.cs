﻿using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IPostReactionRepository : IGenericRepository<PostReaction>
    {
        Task<ICollection<PostReaction>> GetByPost(Guid postId);
        Task<ICollection<PostReaction>> GetByUser(string userId);
        Task<PostReaction> GetById(Guid postId, string userId, int reactionId);
        Task<bool> Delete(Guid postId, string userId, int reactionId);
    }
}
