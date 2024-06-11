using Shared.Abstractions;
using Shared.Abstractions.Messaging;
using Ticketing.Domain.Abstractions;
using Ticketing.Domain.Entities;
using Ticketing.Domain.Errors;

namespace Ticketing.Application.Tickets.Commands.UpdateTicket;

internal class UpdateTicketCommandHandler(IRepository repo)
    : ICommandHandler<UpdateTicketCommand, object>
{
    private readonly IRepository _repo = repo;

    public async Task<Result<object>> Handle(
        UpdateTicketCommand request,
        CancellationToken cancellationToken)
    {
        if (request == null)
        {
            return Error.NullValue(nameof(request));
        }

        if (!request.UpdateUserId.HasValue)
        {
            return new Error("Ticket.BadRequest", "Invalid User", 400);
        }

        var ticket = await _repo.FindByIdAsync<Ticket>(request.Id);

        if (ticket == null)
        {
            return TicketErrors.NotFound($"{request.Id}");
        }

        var updateUser = await _repo.FindByIdAsync<User>(
            request.UpdateUserId.Value);

        if (updateUser == null)
        {
            return new Error("Ticket.BadRequest", "Invalid User", 400);
        }

        if (request.Status.HasValue)
        {
            ticket.Status = request.Status.Value;
        }

        if (request.ActionUserId.HasValue)
        {
            ticket.ActionUserId = request.ActionUserId.Value;
        }

        if (!string.IsNullOrWhiteSpace(request.Title))
        {
            ticket.Title = request.Title;
        }

        if (!string.IsNullOrWhiteSpace(request.Description))
        {
            ticket.Description = request.Description;
        }

        ticket.UpdatedBy = updateUser.Email;

        _repo.Update(ticket);

        await _repo.CommitAsync(cancellationToken);

        return Result<object>.Success();
    }
}
