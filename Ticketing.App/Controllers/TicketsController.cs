using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Application.Tickets.Commands.CreateTicket;
using Ticketing.Application.Tickets.Commands.UpdateTicket;
using Ticketing.Application.Tickets.Queries.GetUserTickets;

namespace Ticketing.Presentation.Controllers
{
    [Route("api/tickets")]
    public class TicketsController(ISender sender)
        : ApiController(sender)
    {
        [Authorize]
        [HttpGet(Name = "Get tickets for current user")]
        public async Task<IActionResult> GetUserTickets(
            CancellationToken cancellationToken)
        {
            var query = new GetUserTicketsQuery(GetUserId());

            return CustomResponse(await Sender.Send(
                query, cancellationToken));
        }

        [Authorize]
        [HttpPost(Name = "Create a ticket")]
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

        [Authorize]
        [HttpPatch("{id}", Name = "Update a ticket")]
        public async Task<IActionResult> UpdateTicket(
            Guid id,
            [FromBody] UpdateTicketRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateTicketCommand(
                id,
                request.Title,
                request.Description,
                GetUserId(),
                request.ActionUserId,
                request.Status);

            return CustomResponse(await Sender.Send(
                command, cancellationToken));
        }
    }
}
