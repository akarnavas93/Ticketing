using Shared.Abstractions;

namespace Ticketing.Domain.Errors;

public static class ShipmentErrors
{
    public static Error ShipmentNotFound(string shipmentData) => new("Shipment.NotFound",
        $"Shipment with info {shipmentData} was not found", 404);
}
