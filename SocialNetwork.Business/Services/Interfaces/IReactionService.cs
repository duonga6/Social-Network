using SocialNetwork.Business.DTOs.Reaction.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;

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
