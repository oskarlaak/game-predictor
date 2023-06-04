using DAL.DTO.Competition;
using Public.DTO.Competition;
using Public.DTO.CompetitionStage;
using Public.DTO.CompetitionUser;
using Public.DTO.Game;
using Public.DTO.GameGroup;
using Public.DTO.Prediction;
using WebApp.Logic;

namespace WebApp.Mappers;

public class CompetitionMapper
{
    public CompetitionDTO Map(CompetitionDALDTO dto)
    {
        return new CompetitionDTO()
        {
            Id = dto.Id,
            Name = dto.Name,
            HasEnded = dto.HasEnded,
            UserIsHost = dto.UserIsHost,
            ActionCount = dto.ActionCount
        };
    }

    public CompetitionPreviewDTO Map(CompetitionPreviewDALDTO dto)
    {
        return new CompetitionPreviewDTO()
        {
            Id = dto.Id,
            Name = dto.Name
        };
    }
    
    public CompetitionTableDTO Map(CompetitionTableDALDTO dto)
    {
        Guid firstCompetitionUserId = dto.CompetitionUsers.First().Id;
        
        return new CompetitionTableDTO()
        {
            Name = dto.Name,
            HasEnded = dto.HasEnded,
            UserIsHost = dto.UserIsHost,
            CompetitionUsers = dto.CompetitionUsers.Select(cu => new CompetitionUserDTO()
            {
                Id = cu.Id,
                Name = cu.Name
            }),
            CompetitionStages = dto.CompetitionStages.Select(cs =>
            {
                PointsCalculator calculator = new(
                    cs.PointsOnCorrectScore,
                    cs.PointsOnCorrectScoreDifference,
                    cs.PointsOnCorrectResult
                );

                return new CompetitionStageDTO()
                {
                    Id = cs.Id,
                    Name = cs.Name,
                    PointsOnCorrectScore = cs.PointsOnCorrectScore,
                    PointsOnCorrectScoreDifference = cs.PointsOnCorrectScoreDifference,
                    PointsOnCorrectResult = cs.PointsOnCorrectResult,
                    GameGroups = cs.GameGroups.Select(gg => new GameGroupDTO()
                    {
                        Id = gg.Id,
                        Name = gg.Name,
                        Games = gg.Games.Select(g =>
                        {
                            bool hidePredictions =
                                g.PredictionDeadlineDT > DateTime.UtcNow &&
                                g.Predictions.All(p => p.CompetitionUserId != firstCompetitionUserId);

                            Score actual = new(g.TeamOneScore, g.TeamTwoScore);

                            return new GameDTO()
                            {
                                Id = g.Id,
                                TeamOneName = g.TeamOneName,
                                TeamTwoName = g.TeamTwoName,
                                TeamOneScore = g.TeamOneScore,
                                TeamTwoScore = g.TeamTwoScore,
                                PredictionDeadlineDT = g.PredictionDeadlineDT,
                                Predictions = g.Predictions.Select(p => new PredictionDTO()
                                {
                                    CompetitionUserId = p.CompetitionUserId,
                                    TeamOneScore = hidePredictions ? null : p.TeamOneScore,
                                    TeamTwoScore = hidePredictions ? null : p.TeamTwoScore,
                                    Points = calculator.Calculate(
                                        actual,
                                        new Score(p.TeamOneScore, p.TeamTwoScore)
                                    ),
                                    IsHidden = hidePredictions
                                })
                            };
                        })
                    })
                };
            })
        };
    }
}
