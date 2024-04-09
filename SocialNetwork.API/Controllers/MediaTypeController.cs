using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.Business.DTOs.Responses;

namespace SocialNetwork.API.Controllers
{
    public class MediaTypeController : BaseController
    {
        private readonly IMediaTypeService _mediaTypeService;

        public MediaTypeController(IMediaTypeService mediaTypeService)
        {
            _mediaTypeService = mediaTypeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(DataResponse<List<GetMediaTypeResponse>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return ResponseModel(await _mediaTypeService.GetAll());
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetMediaTypeResponse>), 200)]
        public async Task<IActionResult> GetById(int Id)
        {
            return ResponseModel(await _mediaTypeService.GetById(Id));
        }
    }
}
