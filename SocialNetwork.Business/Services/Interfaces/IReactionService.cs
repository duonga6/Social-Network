using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IReactionService
    {
        Task<IResponse> GetAll();
        Task<IResponse> GetById(int id);
        Task<IResponse> Add(CreateReactionRequest entity);
        Task<IResponse> Update(int id, UpdateReactionRequest entity);
        Task<IResponse> Delete(int id);
    }
}
