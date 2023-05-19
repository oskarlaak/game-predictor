using Domain.Base;

namespace Domain.App;

public class Game : BaseDomainEntity
{
    public Guid GameDayId { get; set; }
    public GameDay? GameDay { get; set; }

    public string TeamOneName { get; set; } = default!;

    public string TeamTwoName { get; set; } = default!;

    public int? TeamOneScore { get; set; }

    public int? TeamTwoScore { get; set; }

    public DateTime PredictionDeadlineDT { get; set; }

    public DateTime CreatedDT { get; set; }

    public ICollection<Prediction>? Predictions { get; set; }
}
