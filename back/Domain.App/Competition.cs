using Domain.Base;

namespace Domain.App;

public class Competition : BaseDomainEntity
{
    public Guid CompetitionTypeId { get; set; }
    public CompetitionType? CompetitionType { get; set; }

    public string Name { get; set; } = default!;

    public bool HasEnded { get; set; }

    public ICollection<CompetitionUser>? CompetitionUsers { get; set; }
    public ICollection<CompetitionStage>? CompetitionStages { get; set; }
}
