using Ticketing.Domain.Entities;

namespace Ticketing.Domain.Abstractions;

public interface IRepository
{
    void Add<TEntity>(TEntity entity) where TEntity : Entity;

    void Update<TEntity>(TEntity entity) where TEntity : Entity;

    void Remove<TEntity>(TEntity entity) where TEntity : Entity;

    TEntity? FindById<TEntity>(Guid id) where TEntity : Entity;

    Task<TEntity?> FindByIdAsync<TEntity>(Guid id) where TEntity : Entity;

    IQueryable<TEntity> GetQueryableAsync<TEntity>() where TEntity : Entity;
}
