using Shared.Abstractions;

namespace Ticketing.Domain.Errors;

public static class ShipmentErrors
{
    public static Error NotFound(string id) => new("Shipment.NotFound",
        $"Shipment {id} was not found", 404);
}
