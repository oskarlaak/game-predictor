namespace DAL.DTO.Prediction;

public class PredictionDALDTO
{
    public Guid CompetitionUserId { get; set; }
    public int TeamOneScore { get; set; }
    public int TeamTwoScore { get; set; }
}