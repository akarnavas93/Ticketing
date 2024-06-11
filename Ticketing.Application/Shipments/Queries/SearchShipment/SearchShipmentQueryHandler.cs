using Shared.Abstractions;
using Ticketing.Domain.Entities;
using Shared.Abstractions.Messaging;
using Ticketing.Domain.Abstractions;

namespace Ticketing.Application.Shipments.Queries.SearchShipment;

internal sealed class SearchShipmentQueryHandler(IRepository repo)
    : IQueryHandler<SearchShipmentQuery, IList<ShipmentResponse>>
{
    private readonly IRepository _repo = repo;

    public async Task<Result<IList<ShipmentResponse>>> Handle(
        SearchShipmentQuery request,
        CancellationToken cancellationToken)
    {
        if (request == null)
        {
            return Error.NullValue(nameof(request));
        }

        var q = _repo.GetQueryable<Shipment>();

        if (!string.IsNullOrWhiteSpace(request.TrackingNumber))
        {
            q = q.Where(s =>
                s.TrackingNumber.Equals(
                        request.TrackingNumber));
        }

        if (request.Carrier.HasValue)
        {
            q = q.Where(s =>
                s.Carrier == request.Carrier);
        }

        if (!q.Any())
        {
            return new Error("Shipment.NotFound",
                $"Shipment with info {request.TrackingNumber} and {request.Carrier} was not found",
                404);
        }

        var shipments = q.Select(s =>
            new ShipmentResponse(s.Id,
                s.TrackingNumber, s.Carrier, s.Status))
            .ToList();

        return await Task.FromResult(shipments);
    }
}
