namespace Ticketing.Application.Tickets.Commands.CreateTicket;

public class CreateTicketRequest
{
    public Guid? ShpmentId { get; set; }
    public Guid? ActionUserId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
}
