using Shared.Abstractions.Messaging;

namespace Ticketing.Application.Shipments.Queries.GetShipmentById;

public sealed record GetShipmentByIdQuery(Guid ShipmentId)
    : IQuery<ShipmentResponse>;
