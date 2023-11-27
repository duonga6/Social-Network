using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.API.Controllers
{
    public class PostsController : BaseController
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            return await _postService.GetAll();
        }

        [HttpGet("{Id}")]
        public async Task<IResponse> GetById(Guid Id)
        {
            return await _postService.GetById(Id);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody]CreatePostRequest request)
        {
            return await _postService.Create(request);
        }

        [HttpPut("{Id}")]
        public async Task<IResponse> Update(Guid Id, [FromBody] UpdatePostRequest request)
        {
            return await _postService.Update(Id, request);
        }

        [HttpDelete("{Id}")]
        public async Task<IResponse> Delete(Guid Id)
        {
            return await _postService.Delete(Id);
        }
        
    }
}
