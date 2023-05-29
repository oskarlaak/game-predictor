namespace Public.DTO.Prediction;

public class PredictionDTO
{
    public Guid CompetitionUserId { get; set; }
    public int? TeamOneScore { get; set; }
    public int? TeamTwoScore { get; set; }
    public int? Points { get; set; }
    public bool IsHidden { get; set; }
}
