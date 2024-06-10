using Shared.Constants.Enum;

namespace Ticketing.Application.Shipments.Queries.GetShipmentById;

public sealed record ShipmentResponse(
    Guid Id,
    string TrackingNumber,
    ShipmentCarrier Carrier,
    ShipmentTrackingStatus Status);
