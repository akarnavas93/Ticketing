using Shared.Abstractions;

namespace Ticketing.Domain.Errors;

public static class UserErrors
{
    public static Error NotFound(string id) => new("User.NotFound",
        $"User {id} was not found", 404);
}
