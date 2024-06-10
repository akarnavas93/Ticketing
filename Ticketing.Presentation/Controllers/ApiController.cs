using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ticketing.Presentation.Controllers
{
    [ApiController]
    public abstract class ApiController(ISender sender) : ControllerBase
    {
        protected readonly ISender Sender = sender;
    }
}
