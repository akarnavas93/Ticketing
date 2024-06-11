using Shared.Constants.Enum;

namespace Ticketing.Application.Tickets.Queries;

public sealed record TicketResponse(
    Guid Id,
    string Title,
    string Description,
    Guid ShipmentId,
    string ShipmentTrackingNumber,
    ShipmentCarrier ShipmentCarrierId,
    ShipmentTrackingStatus ShipmentTrackingStatus,
    string CreatedBy);
