using Shared.Abstractions;

namespace Ticketing.Domain.Errors;

public static class UserErrors
{
    public static Error UserNotFound(string userData) => new("User.NotFound",
        $"User with info {userData} was not found", 404);
}
