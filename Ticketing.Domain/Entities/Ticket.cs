namespace Ticketing.Domain.Entities;

public class Ticket : Entity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public virtual required Guid CreateUserId { get; set; }
    public virtual required User CreateUser { get; set; }
    public virtual required Guid ActionUserId { get; set; }
    public virtual required User ActionUser { get; set; }
    public virtual required Guid ShipmentId { get; set; }
    public virtual required Shipment Shipment { get; set; }
    public required string CreatedBy { get; set; }
    public required string UpdatedBy { get; set; }
}
