using Ticketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketing.Infrastructure.Configurations;

internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder
            .ToTable("Tickets", schema: "core")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(x => x.CreateUser)
            .WithMany(x => x.CreatedTickets)
            .HasForeignKey(x => x.CreateUserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(x => x.ActionUser)
            .WithMany(x => x.AssignedTickets)
            .HasForeignKey(x => x.ActionUserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(x => x.Shipment)
            .WithMany(x => x.Tickets)
            .HasForeignKey(x => x.ShipmentId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
