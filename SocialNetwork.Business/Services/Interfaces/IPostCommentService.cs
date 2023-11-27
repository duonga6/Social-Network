using SocialNetwork.Business.DTOs.PostComment.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IPostCommentService
    {
        Task<IResponse> GetAll();
        Task<IResponse> GetById(Guid id);
        Task<IResponse> Create(CreatePostCommentRequest request);
        Task<IResponse> Update(Guid id, UpdatePostCommentRequest request);
        Task<IResponse> Delete(Guid id);
    }
}
