using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Presentation.Controllers;
using Ticketing.Application.Tickets.Queries.GetUserTickets;
using Ticketing.Application.Tickets.Commands.CreateTicket;

namespace Ticketing.App.Controllers
{
    [Route("api/tickets")]
    public class TicketsController(ISender sender)
        : ApiController(sender)
    {
        [HttpGet]
        public async Task<IActionResult> GetUserTickets(
            CancellationToken cancellationToken)
        {
            var query = new GetUserTicketsQuery(GetUserId());

            return CustomResponse(await Sender.Send(
                query, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(
            [FromBody] CreateTicketRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateTicketCommand(
                request.Title,
                request.Description,
                GetUserId(),
                request.ActionUserId,
                request.ShpmentId);

            return CustomResponse(await Sender.Send(
                command, cancellationToken));
        }
    }
}
