using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Utilities.Roles;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class ReactionsController : BaseController
    {
        private readonly IReactionService _reactionService;
        public ReactionsController(IReactionService reactionService)
        {
            _reactionService = reactionService;
        }

        /// <summary>
        /// Get all reaction in DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return ResponseModel(await _reactionService.GetAll());
        }

        /// <summary>
        /// Get reaction by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> GetById(int Id)
        {
            return ResponseModel(await _reactionService.GetById(Id));
        }

        /// <summary>
        /// Create reaction (admin)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = RoleName.Administrator)]
        public async Task<IActionResult> Create([FromBody] CreateReactionRequest model)
        {
            return ResponseModel(await _reactionService.Add(model));
        }

        /// <summary>
        /// Update reaction (admin)
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = RoleName.Administrator)]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update(int Id, [FromBody] UpdateReactionRequest model)
        {
            return ResponseModel(await _reactionService.Update(Id, model));
        }

        /// <summary>
        /// Delete reaction (admin)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles = RoleName.Administrator)]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            return ResponseModel(await _reactionService.Delete(Id));
        }

    }
}
