﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class CommentReactionsController : BaseController
    {
        private readonly ICommentReactionService _commentReactionService;

        public CommentReactionsController(ICommentReactionService commentReactionService)
        {
            _commentReactionService = commentReactionService;
        }

        /// <summary>
        /// Create reaction for comment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<GetCommentReactionResponse>), 200)]
        public async Task<IActionResult> Create([FromBody] CreateCommentReactionRequests request)
        {
            return ResponseModel(await _commentReactionService.Create(UserId, request));
        }

        /// <summary>
        /// Delete reaction of comment
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return ResponseModel(await _commentReactionService.Delete(UserId, Id));
        }

        /// <summary>
        /// Get overview reaction of comment
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(DataResponse<GetOverviewReactionResponse>), 200)]
        [HttpGet("{Id}/GetOverview")]        
        public async Task<IActionResult> GetOverview(Guid Id)
        {
            return ResponseModel(await _commentReactionService.GetOverview(UserId, Id));
        }

        /// <summary>
        /// Update reaction of comment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetCommentReactionResponse>), 200)]
        public async Task<IActionResult> Update(Guid id, UpdateCommentReactionRequest request)
        {
            return ResponseModel(await _commentReactionService.Update(UserId, id, request));
        }
        
        /// <summary>
        /// Get comment reaction by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetCommentReactionResponse>), 200)]        
        public async Task<IActionResult> GetById(Guid Id)
        {
            return ResponseModel(await _commentReactionService.GetById(UserId, Id));
        }
        
    }
}
