using DAL.Base;
using Domain.Interfaces.Base;

namespace DAL.App;

public abstract class AppBaseRepo<TEntity> : BaseRepo<TEntity, AppDbContext>
    where TEntity : class, IBaseDomainEntity
{
    protected AppBaseRepo(AppDbContext ctx) : base(ctx)
    {
    }
}
