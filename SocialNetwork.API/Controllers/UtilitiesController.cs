﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Utilities.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Utilities.Roles;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class UtilitiesController : BaseController
    {
        private readonly IMailService _mailService;

        public UtilitiesController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("SendMail")]
        [Authorize(Roles = RoleName.Administrator)]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> SendMail([FromBody] SendMailRequest request)
        {
            return ResponseModel(await _mailService.SendMailAsync(request));
        }
    }
}
