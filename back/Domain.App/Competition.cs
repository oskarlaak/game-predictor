using Domain.Base;

namespace Domain.App;

public class Competition : BaseDomainEntity
{
    public string Name { get; set; } = default!;

    public bool HasEnded { get; set; }

    public ICollection<CompetitionUser>? CompetitionUsers { get; set; }
    public ICollection<CompetitionStage>? CompetitionStages { get; set; }
}
