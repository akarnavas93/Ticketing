using Shared.Constants;

namespace Ticketing.Domain.Entities;

public sealed class User : Entity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string PasswordSalt { get; set; }
    public required AccountType AccountType { get; set; }
}
