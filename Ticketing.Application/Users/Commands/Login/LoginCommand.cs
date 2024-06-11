using Shared.Abstractions.Messaging;

namespace Ticketing.Application.Users.Commands.Login;

public sealed record LoginCommand(
        string Email, string Password)
    : ICommand<string>;
