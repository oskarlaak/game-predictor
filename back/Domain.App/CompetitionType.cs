using Domain.Base;

namespace Domain.App;

public class CompetitionType : BaseDomainEntity
{
    public string Name { get; set; } = default!;

    public ICollection<Competition>? Competitions { get; set; }
}
