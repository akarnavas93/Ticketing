﻿using Shared.Constants;

namespace Ticketing.Domain.Entities;

public sealed class User : Entity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string PasswordSalt { get; set; }
    public required AccountType AccountType { get; set; }
    public IList<Ticket> CreatedTickets { get; set; }
    public IList<Ticket> AssignedTickets { get; set; }

    public User()
    {
        CreatedTickets = new List<Ticket>();
        AssignedTickets = new List<Ticket>();
    }
}
