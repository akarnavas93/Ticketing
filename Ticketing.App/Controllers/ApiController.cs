﻿using MediatR;
using Shared.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Ticketing.Presentation.Controllers
{
    [ApiController]
    public abstract class ApiController(ISender sender) : Controller
    {
        protected readonly ISender Sender = sender;

        public ActionResult CustomResponse<T>(Result<T> result)
        {
            if (result.IsSuccess &&
              result.Value is not null)
            {
                return Ok(result.Value);
            }

            if (result.IsSuccess &&
              result.Value is null)
            {
                return NoContent();
            }

            return Problem(
                title: result.Error.Code,
                detail: result.Error.Description,
                statusCode: result.Error.StatusCode);
        }
    }
}