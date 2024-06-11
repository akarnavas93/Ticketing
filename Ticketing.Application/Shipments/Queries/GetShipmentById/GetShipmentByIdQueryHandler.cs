using Shared.Abstractions;
using Ticketing.Domain.Entities;
using Shared.Abstractions.Messaging;
using Ticketing.Domain.Abstractions;
using Ticketing.Domain.Errors;

namespace Ticketing.Application.Shipments.Queries.GetShipmentById;

internal sealed class GetShipmentByIdQueryHandler(IRepository repo)
    : IQueryHandler<GetShipmentByIdQuery, ShipmentResponse>
{
    private readonly IRepository _repo = repo;

    public async Task<Result<ShipmentResponse>> Handle(
        GetShipmentByIdQuery request,
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

        var response = new ShipmentResponse(
            shipment.Id,
            shipment.TrackingNumber,
            shipment.Carrier,
            shipment.Status);

        return response;
    }
}
