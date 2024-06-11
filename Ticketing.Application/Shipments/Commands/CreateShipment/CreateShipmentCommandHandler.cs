using Shared.Abstractions;
using Shared.Constants.Enum;
using Ticketing.Domain.Entities;
using Shared.Abstractions.Messaging;
using Ticketing.Domain.Abstractions;

namespace Ticketing.Application.Shipments.Commands.CreateShipment;

internal sealed class CreateShipmentCommandHandler(IRepository repo)
        : ICommandHandler<CreateShipmentCommand, Guid>
{
    private readonly IRepository _repo = repo;

    public async Task<Result<Guid>> Handle(
        CreateShipmentCommand request,
        CancellationToken cancellationToken)
    {
        if (request == null)
        {
            return Error.NullValue(nameof(request));
        }

        if (request.ShippedAt.HasValue &&
            request.Status < ShipmentTrackingStatus.Shipped)
        {
            return new Error("Shipment.ValidationError",
                "Cannot give shipped time if shipment not shipped yet",
                400);
        }

        if (request.ArrivedAt.HasValue &&
            request.Status < ShipmentTrackingStatus.Delivered)
        {
            return new Error("Shipment.ValidationError",
                "Cannot give arrival time if shipment not arrived yet",
                400);
        }

        var shipment = new Shipment
        {
            Status = request.Status,
            Carrier = request.Carrier,
            TrackingNumber = request.TrackingNumber,
            CurrentStatusStartedAt = DateTimeOffset.UtcNow,
            ShippedAt = request.ShippedAt?.ToUniversalTime(),
            ArrivedAt = request.ArrivedAt?.ToUniversalTime(),
        };

        _repo.Add(shipment);

        await _repo.CommitAsync(cancellationToken);

        return shipment.Id;
    }
}
