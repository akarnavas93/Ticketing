using Shared.Abstractions.Messaging;

namespace Ticketing.Application.Tickets.Queries.GetUserTickets;

public sealed record GetUserTicketsQuery(Guid UserId)
    : IQuery<UserTicketsResponse>;
