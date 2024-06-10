using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Application.Shipments.Commands.CreateShipment;

namespace Ticketing.Presentation.Controllers;

[Route("api/shipments")]
public sealed class ShipmentController(ISender sender)
    : ApiController(sender)
{
    [HttpPost]
    public async Task<IActionResult> CreateShipment(
        CancellationToken cancellationToken) 
    {
        var command = new CreateShipmentCommand(
            "123456",
            (Shared.Constants.Enum.ShipmentTrackingStatus)1,
            null,
            null);

        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }
}
