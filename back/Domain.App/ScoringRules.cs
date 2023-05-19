using Domain.Base;

namespace Domain.App;

public class ScoringRules : BaseDomainEntity
{
    public string Name { get; set; } = default!;

    public int PointsOnCorrectScore { get; set; }

    public int PointsOnCorrectScoreDifference { get; set; }

    public int PointsOnCorrectResult { get; set; }

    public int PointsMultiplier { get; set; }

    public ICollection<CompetitionStage>? CompetitionStages { get; set; }
}
