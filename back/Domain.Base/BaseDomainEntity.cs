using Domain.Interfaces.Base;

namespace Domain.Base;

public abstract class BaseDomainEntity : IBaseDomainEntity
{
    public Guid Id { get; set; }
}
