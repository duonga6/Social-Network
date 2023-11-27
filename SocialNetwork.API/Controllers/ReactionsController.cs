using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.Reaction.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Utilities.Roles;

namespace SocialNetwork.API.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class ReactionsController : BaseController
    {
        private readonly IReactionService _reactionService;
        public ReactionsController(IReactionService reactionService)
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
        [Route("{Id:guid}")]
        public async Task<IResponse> Update(Guid Id, [FromBody] UpdateReactionRequest model)
        {
            return await _reactionService.Update(Id, model);
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IResponse> Delete(Guid Id)
        {
            return await _reactionService.Delete(Id);
        }

    }
}
