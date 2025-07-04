﻿using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IPostService
    {
        Task<IResponse> GetAll(string requestUserId, string? searchString, int pageSize, int pageNumber);
        Task<IResponse> GetCursor(string requestUserId, int pageSize, DateTime? cursor, string? searchString);
        Task<IResponse> SearchCursor(string requestUserId, int pageSize, DateTime? cursor, string? searchString);
        Task<IResponse> GetById(string requestingUserId, Guid id);
        Task<IResponse> Create(string requestUserId, CreatePostRequest request);
        Task<IResponse> CreateShare(string requestUserId, CreateSharePostRequest request);
        Task<IResponse> Update(string requestingUserId, Guid id, UpdatePostRequest request);
        Task<IResponse> Delete(string requestingUserId, Guid postId);


        Task<IResponse> GetComments(string requestUserId, Guid postId, string? searchString, int pageSize, int pageNumber);
        Task<IResponse> GetCommentById(string requestUserId, Guid postId, Guid commentId);
        Task<IResponse> CreateComment(string requestUserId, Guid postId, CreatePostCommentRequest request);
        Task<IResponse> UpdateComment(string requestUserId, Guid postId, Guid commentId, UpdatePostCommentRequest request);
        Task<IResponse> DeleteComment(string requestUserId, Guid postId, Guid commentId);

        Task<IResponse> GetAllReactions(string requestUserId, Guid postId, int pageSize, int pageNumber);
        Task<IResponse> GetReactionById(string requestUserId, Guid postId,int reactionId);
        Task<IResponse> CreateReaction(string requestUserId, Guid postId, CreatePostReactionRequest request);
        Task<IResponse> UpdateReaction(string requestUserId, Guid postId,int reactionId, CreatePostReactionRequest request);
        Task<IResponse> DeleteReaction(string requestUserId, Guid postId,int reactionId);

        Task<bool> CheckPermission(string userId, Guid postId);

        Task<IResponse> StatsReport(string requestUserId);
    
    }
}
