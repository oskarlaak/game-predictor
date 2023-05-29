using BLL.DTO.Prediction;

namespace BLL.DTO.Game;

public class GameBLLDTO
{
    public Guid Id { get; set; }
    public string TeamOneName { get; set; } = default!;
    public string TeamTwoName { get; set; } = default!;
    public int? TeamOneScore { get; set; }
    public int? TeamTwoScore { get; set; }
    public DateTime PredictionDeadlineDT { get; set; }
    public IEnumerable<PredictionBLLDTO> Predictions { get; set; } = default!;
}
