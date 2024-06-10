using Shared.Abstractions;
using Ticketing.Domain.Entities;
using Shared.Abstractions.Messaging;
using Ticketing.Domain.Abstractions;

namespace Ticketing.Application.Shipments.Commands.CreateShipment;

internal sealed class CreateShipmentCommandHandler : ICommandHandler<CreateShipmentCommand, Guid>
{
    private readonly IRepository _repo;
    private readonly IUnitOfWork _unitOfWork;

    public CreateShipmentCommandHandler(
        IRepository repo,
        IUnitOfWork unitOfWork)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        CreateShipmentCommand request,
        CancellationToken cancellationToken)
    {
        var shipment = new Shipment
        {
            Status = request.Status,
            ShippedAt = request.ShippedAt,
            ArrivedAt = request.ArrivedAt,
            TrackingNumber = request.TrackingNumber,
        };

        _repo.Add(shipment);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return shipment.Id;
    }
}
