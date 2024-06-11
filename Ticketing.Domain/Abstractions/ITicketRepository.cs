using Ticketing.Domain.Entities;

namespace Ticketing.Domain.Abstractions;

public interface ITicketRepository
{
    IQueryable<Ticket> GetAssignedTickets(Guid assignedUserId);
    IQueryable<Ticket> GetCreatedTickets(Guid createUserId);
}
