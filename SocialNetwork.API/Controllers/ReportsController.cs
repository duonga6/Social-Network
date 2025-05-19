using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Abstract;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.DataAccess.Enums;
using SocialNetwork.DataAccess.Utilities;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class ReportsController : BaseController
    {
        private readonly IReportsService _reportsService;

        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        /// <summary>
        /// Create report
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<GetReportResponse>), 201)]
        public async Task<IActionResult> Create(CreateReportRequest request)
        {
            return ResponseModel(await _reportsService.CreateReport(UserId, request));
        }


        /// <summary>
        /// Get report
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="searchString"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Authorize(Roles = RoleName.Administrator)]
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<GetReportResponse>>), 200)]
        public async Task<IActionResult> Get([Required, FromQuery, Range(0, int.MaxValue)]int pageSize, [Required, FromQuery, Range(0, int.MaxValue)] int pageNumber, string? searchString,[FromQuery] ReportTypeEnum? type)
        {
            return ResponseModel(await _reportsService.GetReport(UserId, pageSize, pageNumber, searchString, type));
        }

        /// <summary>
        /// Get report by Id
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Authorize(Roles = RoleName.Administrator)]
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetReportResponse>), 200)]
        public async Task<IActionResult> GetById(Guid Id)
        {
            return ResponseModel(await _reportsService.GetReportById(UserId, Id));
        }

        /// <summary>
        /// Get mark procecced report
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Authorize(Roles = RoleName.Administrator)]
        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetReportResponse>), 200)]
        public async Task<IActionResult> MarkProcess(Guid Id)
        {
            return ResponseModel(await _reportsService.MarkProccessed(UserId, Id));
        }

        /// <summary>
        /// Get action of a report
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Authorize(Roles = RoleName.Administrator)]
        [ProducesResponseType(typeof(DataResponse<List<GetReportActionResponse>>), 200)]
        [HttpGet("{Id}/Actions")]
        public async Task<IActionResult> GetAction(Guid Id)
        {
            return ResponseModel(await _reportsService.GetActionReport(UserId, Id));
        }

        /// <summary>
        /// Create action for report
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Authorize(Roles = RoleName.Administrator)]
        [ProducesResponseType(typeof(DataResponse<GetReportActionDidResponse>), 201)]
        [HttpPost("{Id}/Actions")]
        public async Task<IActionResult> CreateAction(Guid Id,[FromBody] CreateReportActionRequest request)
        {
            return ResponseModel(await _reportsService.CreateActionReport(UserId, Id, request));
        }

        /// <summary>
        /// Undo action for report
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="actionId"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Authorize(Roles = RoleName.Administrator)]
        [ProducesResponseType(typeof(DataResponse<GetReportActionDidResponse>), 200)]
        [HttpDelete("{Id}/Actions/{actionId}")]
        public async Task<IActionResult> DeleteAction(Guid Id, Guid actionId)
        {
            return ResponseModel(await _reportsService.DeleteActionReport(UserId, Id, actionId));
        }

        [AllowAnonymous]
        [Authorize(Roles = RoleName.Administrator)]
        [ProducesResponseType(typeof(DataResponse<GetStatsReportResponse>), 200)]
        [HttpGet("Stats")]
        public async Task<IActionResult> GetStats()
        {
            return ResponseModel(await _reportsService.GetStats(UserId));
        }
    }
}
