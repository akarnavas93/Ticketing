using Shared.Abstractions;
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
