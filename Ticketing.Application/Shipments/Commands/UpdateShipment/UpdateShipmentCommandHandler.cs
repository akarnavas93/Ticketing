using Shared.Abstractions;
using Ticketing.Domain.Errors;
using Ticketing.Domain.Entities;
using Shared.Abstractions.Messaging;
using Ticketing.Domain.Abstractions;

namespace Ticketing.Application.Shipments.Commands.UpdateShipment;

internal sealed class UpdateShipmentCommandHandler(IRepository repo)
    : ICommandHandler<UpdateShipmentCommand, object>
{
    private readonly IRepository _repo = repo;

    public async Task<Result<object>> Handle(
        UpdateShipmentCommand request,
        CancellationToken cancellationToken)
    {
        if (request == null)
        {
            return Error.NullValue(nameof(request));
        }

        var shipment = await _repo.FindByIdAsync<Shipment>(
            request.ShipmentId);

        if (shipment == null)
        {
            return ShipmentErrors.NotFound($"{request.ShipmentId}");
        }

        if (request.Carrier.HasValue)
        {
            shipment.Carrier = request.Carrier.Value;
        }

        if (request.Status.HasValue)
        {
            if (request.Status.Value != shipment.Status)
            {
                shipment.Status = request.Status.Value;
                shipment.CurrentStatusStartedAt = DateTimeOffset.UtcNow;
            }

            switch (shipment.Status)
            {
                case Shared.Constants.Enum.ShipmentTrackingStatus.Shipped:
                    shipment.ShippedAt = DateTimeOffset.UtcNow;
                    break;
                case Shared.Constants.Enum.ShipmentTrackingStatus.Delivered:
                    shipment.ArrivedAt = DateTimeOffset.UtcNow;
                    break;
            }
        }

        _repo.Update(shipment);

        await _repo.CommitAsync(cancellationToken);

        return Result<object>.Success();
    }
}
