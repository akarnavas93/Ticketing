using Shared.Constants.Enum;
using Shared.Abstractions.Messaging;

namespace Ticketing.Application.Shipments.Commands.UpdateShipment;

public sealed record UpdateShipmentCommand(
    Guid ShipmentId,
    string? TrackingNumber,
    ShipmentTrackingStatus? Status,
    ShipmentCarrier? Carrier) : ICommand<object>;
