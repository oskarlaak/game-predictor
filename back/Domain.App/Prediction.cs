using Domain.Base;

namespace Domain.App;

public class Prediction : BaseDomainEntity
{
    public Guid GameId { get; set; }
    public Game? Game { get; set; }

    public Guid CompetitionUserId { get; set; }
    public CompetitionUser? CompetitionUser { get; set; }

    public int TeamOneScore { get; set; }

    public int TeamTwoScore { get; set; }
}
