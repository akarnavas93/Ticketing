using Ticketing.Domain.Entities;

namespace Ticketing.Domain.Abstractions;

public interface IShipmentRepository
{
    Task<Shipment> GetByIdAsync(Guid shipmentId);
}
