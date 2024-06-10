using Ticketing.Domain.Entities;
using Ticketing.Domain.Abstractions;

namespace Ticketing.Infrastructure.Repositories;

public abstract class Repository : IRepository
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public void Add<TEntity>(TEntity entity) where TEntity : Entity
    {
        DbContext.Set<TEntity>().Add(entity);
    }

    public void Update<TEntity>(TEntity entity) where TEntity : Entity
    {
        DbContext.Set<TEntity>().Update(entity);
    }

    public void Remove<TEntity>(TEntity entity) where TEntity : Entity
    {
        DbContext.Set<TEntity>().Remove(entity);
    }

    public virtual TEntity? FindById<TEntity>(Guid id) where TEntity : Entity
    {
        return DbContext.Set<TEntity>().Find(id);
    }

    public virtual async Task<TEntity?> FindByIdAsync<TEntity>(Guid id) where TEntity : Entity
    {
        return await DbContext.Set<TEntity>().FindAsync(id);
    }

    public virtual IQueryable<TEntity> GetQueryableAsync<TEntity>() where TEntity : Entity
    {
        return DbContext.Set<TEntity>();
    }
}
