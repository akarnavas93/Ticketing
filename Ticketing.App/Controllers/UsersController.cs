using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Application.Users.Commands.Login;

namespace Ticketing.Presentation.Controllers;

[Route("api/users")]
public sealed class UsersController(ISender sender)
    : ApiController(sender)
{
    [HttpPost("login", Name = "User login, get token")]
    public async Task<IActionResult> LoginUser(
        [FromBody] LoginRequest loginRequest,
        CancellationToken cancellationToken)
    {
        var loginCommand = new LoginCommand(
            loginRequest.Email,
            loginRequest.Password);

        return CustomResponse(await Sender.Send(
            loginCommand, cancellationToken));
    }
}
