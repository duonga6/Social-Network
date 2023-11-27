using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.PostComment.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.API.Controllers
{
    public class PostComments : BaseController
    {
        private readonly IPostCommentService _postCommentService;

        public PostComments(IPostCommentService postCommentService)
        {
            _postCommentService = postCommentService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            return await _postCommentService.GetAll();
        }

        [HttpGet("{Id}")]
        public async Task<IResponse> GetById(Guid Id) 
        {
            return await _postCommentService.GetById(Id);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] CreatePostCommentRequest request)
        {
            return await _postCommentService.Create(request);
        }

        [HttpPut("{Id}")]
        public async Task<IResponse> Update(Guid Id, [FromBody] UpdatePostCommentRequest request)
        {
            return await _postCommentService.Update(Id, request);
        }

        [HttpDelete("{Id}")]
        public async Task<IResponse> Delete(Guid Id)
        {
            return await _postCommentService.Delete(Id);
        }
    }
}
