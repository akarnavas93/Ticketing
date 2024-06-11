using MediatR;
using Shared.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        protected Guid GetUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                return Guid.Parse(userId);
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }
    }
}
