using Shared.Abstractions.Messaging;
namespace Ticketing.Application.Tickets.Commands.CreateTicket;

public sealed record CreateTicketCommand(
    string Title,
    string Description,
    Guid? CreateUserId,
    Guid? ActionUserId,
    Guid? ShipmentId) : ICommand<Guid>;
