using Shared.Constants.Enum;

namespace Ticketing.Domain.Entities;

public sealed class Shipment : Entity
{
    public required string TrackingNumber { get; set; }
    public ShipmentTrackingStatus Status { get; set; }
    public ShipmentCarrier Carrier { get; set; }
    public DateTimeOffset? ShippedAt { get; set; }
    public DateTimeOffset? ArrivedAt { get; set; }
    public DateTimeOffset? CurrentStatusStartedAt { get; set; }
    public IList<Ticket> Tickets { get; set; }

    public Shipment()
    {
        Tickets = new List<Ticket>();
        Status = ShipmentTrackingStatus.Unknown;
    }
}
