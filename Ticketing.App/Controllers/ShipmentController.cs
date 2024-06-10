using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Application.Shipments.Commands.CreateShipment;
using Ticketing.Application.Shipments.Queries.GetShipmentById;

namespace Ticketing.Presentation.Controllers;

[Route("api/shipments")]
public sealed class ShipmentController(ISender sender)
    : ApiController(sender)
{
    [HttpPost(Name = "Create a shipment")]
    public async Task<IActionResult> CreateShipmentAsync(
        [FromBody] CreateShipmentCommand shipmentCommand,
        CancellationToken cancellationToken) 
    {
        return CustomResponse(await Sender.Send(
            shipmentCommand, cancellationToken));
    }

    [HttpGet("{id}", Name = "Get a specific shipment")]
    public async Task<IActionResult> GetShipmentByIdAsync(
        Guid id, CancellationToken cancellationToken)
    {
        return CustomResponse(await Sender.Send(
            new GetShipmentByIdQuery(id), cancellationToken));
    }
}
