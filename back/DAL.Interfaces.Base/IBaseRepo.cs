using Domain.Interfaces.Base;

namespace DAL.Interfaces.Base;

public interface IBaseRepo<TEntity> where TEntity : class, IBaseDomainEntity
{
    
}
