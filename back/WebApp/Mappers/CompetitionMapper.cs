using BLL.DTO.Competition;
using Public.DTO.Competition;
using Public.DTO.CompetitionStage;
using Public.DTO.CompetitionUser;
using Public.DTO.Game;
using Public.DTO.GameGroup;
using Public.DTO.Prediction;

namespace WebApp.Mappers;

public class CompetitionMapper
{
    public CompetitionDTO Map(CompetitionBLLDTO dto)
    {
        return new CompetitionDTO()
        {
            Id = dto.Id,
            Name = dto.Name,
            Type = dto.Type,
            HasEnded = dto.HasEnded,
            UserIsHost = dto.UserIsHost,
            ActionCount = dto.ActionCount
        };
    }

    public CompetitionTableDTO Map(CompetitionTableBLLDTO dto)
    {
        return new CompetitionTableDTO()
        {
            CompetitionUsers = dto.CompetitionUsers.Select(cu => new CompetitionUserDTO()
            {
                Id = cu.Id,
                Name = cu.Name
            }),
            CompetitionStages = dto.CompetitionStages.Select(cs => new CompetitionStageDTO()
            {
                Id = cs.Id,
                Name = cs.Name,
                ScoringRulesName = cs.ScoringRulesName,
                GameGroups = cs.GameGroups.Select(gg => new GameGroupDTO()
                {
                    Id = gg.Id,
                    Name = gg.Name,
                    Games = gg.Games.Select(g => new GameDTO()
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
                            TeamOneScore = p.TeamOneScore,
                            TeamTwoScore = p.TeamTwoScore,
                            Points = p.Points,
                            IsHidden = p.IsHidden
                        })
                    })
                })
            })
        };
    }
}
