using Shared.Constants;

namespace Ticketing.Application.Tickets.Commands.UpdateTicket;

public class UpdateTicketRequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Guid? ActionUserId { get; set; }
    public TicketStatus? Status { get; set; }
}
