using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants.Enum;

using Ticketing.Application.Shipments.Queries.SearchShipment;
using Ticketing.Application.Shipments.Commands.CreateShipment;
using Ticketing.Application.Shipments.Commands.UpdateShipment;
using Ticketing.Application.Shipments.Queries.GetShipmentById;
using Microsoft.AspNetCore.Authorization;

namespace Ticketing.Presentation.Controllers;

[Route("api/shipments")]
public sealed class ShipmentsController(ISender sender)
    : ApiController(sender)
{
    [Authorize]
    [HttpGet(Name = "Get all shpiments")]
    public async Task<IActionResult> GetShipmentsAsync(
        string? trackingNumber, ShipmentCarrier? carrierId)
    {
        return CustomResponse(await Sender.Send(
            new SearchShipmentQuery(trackingNumber, carrierId)));
    }

    [Authorize]
    [HttpPatch(Name = "Update a shipment")]
    public async Task<IActionResult> UpdateShipmentAsync(
        [FromBody] UpdateShipmentCommand updateShipmentCommand,
        CancellationToken cancellationToken)
    {
        return CustomResponse(await Sender.Send(
            updateShipmentCommand, cancellationToken));
    }

    [Authorize]
    [HttpPost(Name = "Create a shipment")]
    public async Task<IActionResult> CreateShipmentAsync(
        [FromBody] CreateShipmentCommand shipmentCommand,
        CancellationToken cancellationToken) 
    {
        return CustomResponse(await Sender.Send(
            shipmentCommand, cancellationToken));
    }

    [Authorize]
    [HttpGet("{id}", Name = "Get a specific shipment")]
    public async Task<IActionResult> GetShipmentByIdAsync(
        Guid id, CancellationToken cancellationToken)
    {
        return CustomResponse(await Sender.Send(
            new GetShipmentByIdQuery(id), cancellationToken));
    }
}
