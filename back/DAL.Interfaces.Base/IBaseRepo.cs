using Domain.Interfaces.Base;

namespace DAL.Interfaces.Base;

public interface IBaseRepo<TEntity> where TEntity : class, IBaseDomainEntity
{
    Task<TEntity?> GetById(Guid id);
    
    Task<bool> HasEntityWithId(Guid id);
    
    Task<Guid> Add(TEntity entity);
    
    Task<bool> DeleteById(Guid id);
}
