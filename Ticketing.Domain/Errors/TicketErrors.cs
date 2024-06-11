using Shared.Abstractions;

namespace Ticketing.Domain.Errors;

public static class TicketErrors
{
    public static Error NotFound(string id) => new("Ticket.NotFound",
        $"Ticket {id} was not found", 404);
}
