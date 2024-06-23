﻿using BookBee.Application.Exceptions;
using BookBee.Application.External.SendGridEmail;
using BookBee.Application.Features;
using BookBee.Domain.Models.SendGridEmailRequestModel;
using Microsoft.AspNetCore.Mvc;

namespace BookBee.Api.Controllers
{
    [Route("api/v1/notification")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class NotificationController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] SendGridEmailRequestModel model,
            [FromServices] ISendGridEmailService sendGridEmailService)
        {
            var data = await sendGridEmailService.Execute(model);

            if (!data)
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseApiService.Response(StatusCodes.Status500InternalServerError));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK));
        }
    }
}