namespace Shared.Primitives.Entities;

public interface IEntity
{
    Guid Id { get;}
    DateTimeOffset Created { get; }
    DateTimeOffset Modified { get; }
}
