namespace Ticketing.Application.Tickets.Queries;

public sealed record UserTicketsResponse(
    IList<TicketResponse> AssignedTickets,
    IList<TicketResponse> CreatedTickets);
