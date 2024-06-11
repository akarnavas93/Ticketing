using Ticketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketing.Infrastructure.Configurations;

internal class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder
            .ToTable("Shipments", schema: "application")
            .HasKey(s => s.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasIndex(x => new { x.TrackingNumber, x.Carrier })
            .IsUnique();

        builder.HasData(
            new Shipment
            {
                Id = Guid.Parse("2f7dcf39-6acf-4d86-99b6-77f43e4640ea"),
                TrackingNumber = "GR455115566874",
                Status = Shared.Constants.Enum.ShipmentTrackingStatus.Unknown,
                Carrier = Shared.Constants.Enum.ShipmentCarrier.Carrier1,
                CurrentStatusStartedAt = DateTimeOffset.UtcNow
            },
            new Shipment
            {
                Id = Guid.Parse("633af550-199e-4f6a-9f0b-2bbdb8bfa54a"),
                TrackingNumber = "GR455115566874",
                Status = Shared.Constants.Enum.ShipmentTrackingStatus.Shipped,
                Carrier = Shared.Constants.Enum.ShipmentCarrier.Carrier2,
                CurrentStatusStartedAt = DateTimeOffset.UtcNow,
                ShippedAt = DateTimeOffset.UtcNow
            },
            new Shipment
            {
                Id = Guid.Parse("4a204506-2e69-4fd3-b094-cd10958bb9aa"),
                TrackingNumber = "RT4558654654654",
                Status = Shared.Constants.Enum.ShipmentTrackingStatus.EnRoute,
                Carrier = Shared.Constants.Enum.ShipmentCarrier.Carrier1,
                CurrentStatusStartedAt = DateTimeOffset.UtcNow,
                ShippedAt = DateTimeOffset.UtcNow.AddDays(-2)
            },
            new Shipment
            {
                Id = Guid.Parse("b1fd90e6-de43-4593-89fe-c229cf31fb06"),
                TrackingNumber = "FR566546548864",
                Status = Shared.Constants.Enum.ShipmentTrackingStatus.Delivered,
                Carrier = Shared.Constants.Enum.ShipmentCarrier.Carrier3,
                CurrentStatusStartedAt = DateTimeOffset.UtcNow,
                ShippedAt = DateTimeOffset.UtcNow.AddDays(-2),
                ArrivedAt = DateTimeOffset.UtcNow
            },
            new Shipment
            {
                Id = Guid.Parse("a0d8f874-0f67-4768-ab62-81813c0cc4cc"),
                TrackingNumber = "GR455115566874",
                Status = Shared.Constants.Enum.ShipmentTrackingStatus.ArrivedAtPickupPoint,
                Carrier = Shared.Constants.Enum.ShipmentCarrier.Carrier4,
                CurrentStatusStartedAt = DateTimeOffset.UtcNow,
                ShippedAt = DateTimeOffset.UtcNow.AddDays(-3)
            }
            );
    }
}
