using Ticketing.Domain.Entities;

namespace Ticketing.Infrastructure.Repositories;

public abstract class Repository<TEntity>
    where TEntity : Entity
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public void Add(TEntity entity)
    {
        DbContext.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        DbContext.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
    }

    public TEntity? FindById(Guid id)
    {
        return DbContext.Set<TEntity>().Find(id);
    }

    public async Task<TEntity?> FindByIdAsync(Guid id)
    {
        return await DbContext.Set<TEntity>().FindAsync(id);
    }
}
