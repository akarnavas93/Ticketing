using Ticketing.Domain.Abstractions;
using Ticketing.Domain.Entities;

namespace Ticketing.Infrastructure.Repositories;

public sealed class ShipmentRepository : Repository<Shipment>, IShipmentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ShipmentRepository(ApplicationDbContext dbContext)
        :base(dbContext)
    {
        _dbContext = dbContext;
    }
}
