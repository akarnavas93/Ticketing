using Shared.Abstractions;
using Ticketing.Domain.Entities;
using Shared.Abstractions.Messaging;
using Ticketing.Domain.Abstractions;

namespace Ticketing.Application.Tickets.Commands.CreateTicket
{
    internal sealed class CreateTicketCommandHandler(IRepository repo)
        : ICommandHandler<CreateTicketCommand, Guid>
    {
        private readonly IRepository _repo = repo;

        public async Task<Result<Guid>> Handle(
            CreateTicketCommand request,
            CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return Error.NullValue(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return Error.NullValue(nameof(request.Title));
            }

            if (string.IsNullOrWhiteSpace(request.Description))
            {
                return Error.NullValue(nameof(request.Description));
            }

            if (!request.CreateUserId.HasValue)
            {
                return Error.NullValue(nameof(request.CreateUserId));
            }

            if (!request.ActionUserId.HasValue)
            {
                return Error.NullValue(nameof(request.ActionUserId));
            }

            if (!request.ShipmentId.HasValue)
            {
                return Error.NullValue(nameof(request.ShipmentId));
            }

            var createUser = await _repo.FindByIdAsync<User>(
                request.CreateUserId.Value);

            if (createUser == null)
            {
                return new Error("Ticket.BadRequest", "Could not find user to create ticket", 400);
            }

            var ticket = new Ticket
            {
                Title = request.Title,
                Description = request.Description,
                ActionUserId = request.ActionUserId.Value,
                CreateUserId = request.CreateUserId.Value,
                ShipmentId = request.ShipmentId.Value,
                CreatedBy = createUser.Email,
                UpdatedBy = createUser.Email
            };

            _repo.Add(ticket);

            await _repo.CommitAsync(cancellationToken);

            return ticket.Id;
        }
    }
}
