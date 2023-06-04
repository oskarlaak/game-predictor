namespace Public.DTO.Prediction;

public class PredictionPostDTO
{
    public Guid GameId { get; set; }
    public Guid CompetitionUserId { get; set; }
    public int TeamOneScore { get; set; }
    public int TeamTwoScore { get; set; }
}
