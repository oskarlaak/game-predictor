using Domain.Base;

namespace Domain.App;

public class CompetitionStage : BaseDomainEntity
{
    public Guid CompetitionId { get; set; }
    public Competition? Competition { get; set; }

    public string Name { get; set; } = default!;

    public int PointsOnCorrectScore { get; set; }

    public int PointsOnCorrectScoreDifference { get; set; }

    public int PointsOnCorrectResult { get; set; }
    
    public DateTime CreatedDT { get; set; }

    public ICollection<GameGroup>? GameGroups { get; set; }
}
