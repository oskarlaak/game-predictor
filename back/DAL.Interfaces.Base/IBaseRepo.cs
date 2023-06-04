using Domain.Interfaces.Base;

namespace DAL.Interfaces.Base;

public interface IBaseRepo<TEntity> where TEntity : class, IBaseDomainEntity
{
    Task<TEntity> Get(Guid id);
    
    Task<bool> DoesNotHaveEntity(Guid id);
    
    Task<Guid> Add(TEntity entity);
    
    Task Delete(Guid id);
}
