using BLL.App.Logic;
using BLL.DTO.Competition;
using BLL.DTO.CompetitionStage;
using BLL.DTO.CompetitionUser;
using BLL.DTO.Game;
using BLL.DTO.GameGroup;
using BLL.DTO.Prediction;
using DAL.DTO.Competition;

namespace BLL.App.Mappers;

public class CompetitionMapperBLL
{
    public CompetitionBLLDTO Map(CompetitionDALDTO dto)
    {
        return new CompetitionBLLDTO()
        {
            Id = dto.Id,
            Name = dto.Name,
            Type = dto.Type,
            HasEnded = dto.HasEnded,
            UserIsHost = dto.UserIsHost,
            ActionCount = dto.ActionCount
        };
    }

    public CompetitionTableBLLDTO Map(CompetitionTableDALDTO dto)
    {
        Guid competitionUserId = dto.CompetitionUsers.First().Id;
        
        return new CompetitionTableBLLDTO()
        {
            CompetitionUsers = dto.CompetitionUsers.Select(cu => new CompetitionUserBLLDTO()
            {
                Id = cu.Id,
                Name = cu.Name
            }),
            CompetitionStages = dto.CompetitionStages.Select(cs =>
            {
                PointsCalculator calculator = new(
                    cs.PointsOnCorrectScore * cs.PointsMultiplier,
                    cs.PointsOnCorrectScoreDifference * cs.PointsMultiplier,
                    cs.PointsOnCorrectResult * cs.PointsMultiplier
                );

                return new CompetitionStageBLLDTO()
                {
                    Id = cs.Id,
                    Name = cs.Name,
                    ScoringRulesName = cs.ScoringRulesName,
                    GameGroups = cs.GameGroups.Select(gg => new GameGroupBLLDTO()
                    {
                        Id = gg.Id,
                        Name = gg.Name,
                        Games = gg.Games.Select(g =>
                        {
                            bool hidePredictions =
                                g.PredictionDeadlineDT > DateTime.UtcNow &&
                                g.Predictions.All(p => p.CompetitionUserId != competitionUserId);

                            Score actual = new(g.TeamOneScore, g.TeamTwoScore);
                            
                            return new GameBLLDTO()
                            {
                                Id = g.Id,
                                TeamOneName = g.TeamOneName,
                                TeamTwoName = g.TeamTwoName,
                                TeamOneScore = g.TeamOneScore,
                                TeamTwoScore = g.TeamTwoScore,
                                PredictionDeadlineDT = g.PredictionDeadlineDT,
                                Predictions = g.Predictions.Select(p => new PredictionBLLDTO()
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
