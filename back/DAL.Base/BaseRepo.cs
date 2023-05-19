using DAL.Interfaces.Base;
using Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base;

public abstract class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : class, IBaseDomainEntity
{
    protected readonly DbSet<TEntity> DbSet;

    protected BaseRepo(DbContext ctx)
    {
        DbSet = ctx.Set<TEntity>();
    }
}
