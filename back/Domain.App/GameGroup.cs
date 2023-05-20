using Domain.Base;

namespace Domain.App;

public class GameGroup : BaseDomainEntity
{
    public Guid CompetitionStageId { get; set; }
    public CompetitionStage? CompetitionStage { get; set; }

    public string Name { get; set; } = default!;

    public DateTime CreatedDT { get; set; }

    public ICollection<Game>? Games { get; set; }
}
