using DAL.Base;
using Domain.Interfaces.Base;

namespace DAL.App;

public class AppBaseRepo<TEntity> : BaseRepo<TEntity, AppDbContext>
    where TEntity : class, IBaseDomainEntity
{
    public AppBaseRepo(AppDbContext ctx) : base(ctx)
    {
    }
}
