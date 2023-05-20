using Domain.Base;

namespace Domain.App;

public class CompetitionStage : BaseDomainEntity
{
    public Guid CompetitionId { get; set; }
    public Competition? Competition { get; set; }

    public Guid ScoringRulesId { get; set; }
    public ScoringRules? ScoringRules { get; set; }

    public string Name { get; set; } = default!;

    public DateTime CreatedDT { get; set; }

    public ICollection<GameGroup>? GameGroups { get; set; }
}
