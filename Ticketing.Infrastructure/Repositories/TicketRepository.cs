using Microsoft.EntityFrameworkCore;
using Ticketing.Domain.Abstractions;
using Ticketing.Domain.Entities;

namespace Ticketing.Infrastructure.Repositories;

public class TicketRepository(ApplicationDbContext dbContext) : ITicketRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public IQueryable<Ticket> GetAssignedTickets(Guid assignedUserId)
    {
        return _dbContext.Set<Ticket>()
            .Where(t => t.ActionUserId == assignedUserId)
            .Include(s => s.Shipment)
            .Include(u => u.ActionUser)
            .Include(u => u.CreateUser);
    }

    public IQueryable<Ticket> GetCreatedTickets(Guid createUserId)
    {
        return _dbContext.Set<Ticket>()
            .Where(t => t.CreateUserId == createUserId)
            .Include(s => s.Shipment)
            .Include(u => u.ActionUser)
            .Include(u => u.CreateUser);
    }
}
