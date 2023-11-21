using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.Reaction.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.API.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ReactionController : BaseController
    {
        private readonly IReactionService _reactionService;
        public ReactionController(IReactionService reactionService)
        {
            _reactionService = reactionService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            return await _reactionService.GetAll();
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IResponse> GetById(Guid Id)
        {
            return await _reactionService.GetById(Id);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] CreateReactionRequest model)
        {
            return await _reactionService.Add(model);
        }

        [HttpPut]
        public async Task<IResponse> Update([FromBody] UpdateReactionRequest model)
        {
            return await _reactionService.Update(model);
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IResponse> Delete(Guid Id)
        {
            return await _reactionService.Delete(Id);
        }

    }
}
