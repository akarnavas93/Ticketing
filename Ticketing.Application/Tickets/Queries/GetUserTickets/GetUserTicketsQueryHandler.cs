using Shared.Abstractions;
using Ticketing.Domain.Entities;
using Shared.Abstractions.Messaging;
using Ticketing.Domain.Abstractions;

namespace Ticketing.Application.Tickets.Queries.GetUserTickets;

internal sealed class GetUserTicketsQueryHandler(
        IRepository repo, ITicketRepository ticketRepo)
    : IQueryHandler<GetUserTicketsQuery, UserTicketsResponse>
{
    private readonly IRepository _repo = repo;
    private readonly ITicketRepository _ticketRepo = ticketRepo;

    public async Task<Result<UserTicketsResponse>> Handle(
        GetUserTicketsQuery request,
        CancellationToken cancellationToken)
    {
        if (request == null)
        {
            return Error.NullValue(nameof(request));
        }


        var assignedTickets = _repo.GetQueryable<Ticket>()
            .Where(t => t.ActionUserId == request.UserId)
            .ToList();

        var createdTickets = _repo.GetQueryable<Ticket>()
            .Where(t => t.CreateUserId == request.UserId)
            .ToList();

        var assignedTicketsResponse = _ticketRepo
            .GetAssignedTickets(request.UserId)
            .Select(t => new TicketResponse(
                t.Id,
                t.Title,
                t.Description,
                t.Status,
                t.ShipmentId,
                t.Shipment.TrackingNumber,
                t.Shipment.Carrier,
                t.Shipment.Status,
                t.CreatedBy))
            .ToList();

        var createdTicketsResponse = _ticketRepo
            .GetCreatedTickets(request.UserId)
            .Select(t => new TicketResponse(
                t.Id,
                t.Title,
                t.Description,
                t.Status,
                t.ShipmentId,
                t.Shipment.TrackingNumber,
                t.Shipment.Carrier,
                t.Shipment.Status,
                t.CreatedBy))
            .ToList();

        return await Task.FromResult(
            new UserTicketsResponse(assignedTicketsResponse, createdTicketsResponse));
    }
}
