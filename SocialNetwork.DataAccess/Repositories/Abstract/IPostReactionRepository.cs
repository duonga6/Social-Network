﻿using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IPostReactionRepository : IGenericRepository<PostReaction, Guid>
    {
        Task<ICollection<PostReaction>> GetByPost(Guid postId);
        Task<ICollection<PostReaction>> GetByUser(string userId);
        Task<ICollection<int>> GetTypeReaction(Guid postId);
        Task<PostReaction> GetById(Guid postId, string userId, bool noTracking = true);
        Task Delete(Guid postId, string userId);
    }
}
