using Ticketing.Domain.Entities;
using Ticketing.Domain.Abstractions;

namespace Ticketing.Infrastructure.Repositories;

public class Repository(ApplicationDbContext dbContext) : IRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public void Add<TEntity>(TEntity entity) where TEntity : Entity
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public void Update<TEntity>(TEntity entity) where TEntity : Entity
    {
        _dbContext.Set<TEntity>().Update(entity);
    }

    public void Remove<TEntity>(TEntity entity) where TEntity : Entity
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public TEntity? FindById<TEntity>(Guid id) where TEntity : Entity
    {
        return _dbContext.Set<TEntity>().Find(id);
    }

    public async Task<TEntity?> FindByIdAsync<TEntity>(Guid id) where TEntity : Entity
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : Entity
    {
        return _dbContext.Set<TEntity>();
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
