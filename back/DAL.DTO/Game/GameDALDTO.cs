using DAL.DTO.Prediction;

namespace DAL.DTO.Game;

public class GameDALDTO
{
    public Guid Id { get; set; }
    public string TeamOneName { get; set; } = default!;
    public string TeamTwoName { get; set; } = default!;
    public int? TeamOneScore { get; set; }
    public int? TeamTwoScore { get; set; }
    public DateTime PredictionDeadlineDT { get; set; }
    public IEnumerable<PredictionDALDTO> Predictions { get; set; } = default!;
}
