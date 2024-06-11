using Shared.Abstractions.Messaging;
using Shared.Constants.Enum;

namespace Ticketing.Application.Shipments.Queries.SearchShipment;

public sealed record SearchShipmentQuery(string? TrackingNumber,
        ShipmentCarrier? Carrier)
    : IQuery<IList<ShipmentResponse>>
{ 
}
