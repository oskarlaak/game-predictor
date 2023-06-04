using DAL.DTO.Prediction;
using Public.DTO.Prediction;

namespace WebApp.Mappers;

public class PredictionMapper
{
    public PredictionDTO Map(PredictionDALDTO dto)
    {
        return new PredictionDTO()
        {
            CompetitionUserId = dto.CompetitionUserId,
            TeamOneScore = dto.TeamOneScore,
            TeamTwoScore = dto.TeamTwoScore,
            Points = 0,
            IsHidden = false
        };
    }
}