using Shared.Abstractions;

namespace Ticketing.Domain.Errors;

public static class TicketErrors
{
    public static Error TicketNotFound(string ticketData) => new("Ticket.NotFound",
        $"Ticket with info {ticketData} was not found", 404);
}
