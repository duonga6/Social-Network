using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.PostComment.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IPostService
    {
        Task<IResponse> GetAll();
        Task<IResponse> GetById(Guid id);
        Task<IResponse> Create(CreatePostRequest request);
        Task<IResponse> Update(Guid id, UpdatePostRequest request);
        Task<IResponse> Delete(Guid id);
        Task<IResponse> GetAllComment();
        Task<IResponse> GetCommentById(Guid id);
        Task<IResponse> CreateComment(Guid postId, CreatePostCommentRequest request);
        Task<IResponse> UpdateComment(Guid postId, Guid commentId, UpdatePostCommentRequest request);
        Task<IResponse> DeleteComment(Guid postId, Guid commentId);
    }
}
