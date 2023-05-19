using DAL.Interfaces.Base;
using Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base;

public abstract class BaseRepo<TEntity, TDbContext> : IBaseRepo<TEntity>
    where TEntity : class, IBaseDomainEntity
    where TDbContext : DbContext
{
    protected DbSet<TEntity> DbSet { get; set; }

    protected BaseRepo(TDbContext ctx)
    {
        DbSet = ctx.Set<TEntity>();
    }

    public async Task<TEntity?> GetById(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<bool> HasEntityWithId(Guid id)
    {
        return await DbSet.AnyAsync(e => e.Id == id);
    }

    public async Task<Guid> Add(TEntity entity)
    {
        return (await DbSet.AddAsync(entity)).Entity.Id;
    }

    public async Task<bool> DeleteById(Guid id)
    {
        TEntity? entity = await GetById(id);

        if (entity == null) return false;

        DbSet.Remove(entity);

        return true;
    }
}
