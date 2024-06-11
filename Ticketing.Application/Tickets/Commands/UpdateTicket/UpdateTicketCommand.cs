using Shared.Constants;
using Shared.Abstractions.Messaging;

namespace Ticketing.Application.Tickets.Commands.UpdateTicket;

public sealed record UpdateTicketCommand(
    Guid Id,
    string? Title,
    string? Description,
    Guid? UpdateUserId,
    Guid? ActionUserId,
    TicketStatus? Status) : ICommand<object>;