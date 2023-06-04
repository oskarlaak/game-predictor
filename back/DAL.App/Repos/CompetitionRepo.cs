using DAL.DTO.Competition;
using DAL.DTO.CompetitionStage;
using DAL.DTO.CompetitionUser;
using DAL.DTO.Game;
using DAL.DTO.GameGroup;
using DAL.DTO.Prediction;
using DAL.Interfaces.App.Repos;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.Repos;

public class CompetitionRepo : AppBaseRepo<Competition>, ICompetitionRepo
{
    public CompetitionRepo(AppDbContext ctx) : base(ctx)
    {
    }

    public async Task<IEnumerable<CompetitionDALDTO>> GetAllForUser(Guid userId)
    {
        return await DbSet
            .Where(c => c.CompetitionUsers!.Any(cu => cu.UserId == userId))
            .OrderByDescending(c => c.CompetitionUsers!.First(cu => cu.UserId == userId).CreatedDT)
            .Select(c => new CompetitionDALDTO()
            {
                Id = c.Id,
                Name = c.Name,
                HasEnded = c.HasEnded,
                UserIsHost = c.CompetitionUsers!.First(cu => cu.UserId == userId).IsHost,
                ActionCount = (from cs in c.CompetitionStages! from gg in cs.GameGroups! from g in gg.Games! select g)
                    .Count(g =>
                        g.PredictionDeadlineDT > DateTime.UtcNow
                            ? g.Predictions!.All(p => p.CompetitionUser!.UserId != userId)
                            : c.CompetitionUsers!.First(cu => cu.UserId == userId).IsHost &&
                              g.TeamOneScore == null &&
                              g.TeamTwoScore == null
                    )
            })
            .ToListAsync();
    }

    public async Task<CompetitionPreviewDALDTO> GetPreview(Guid id)
    {
        return await DbSet
            .Where(c => c.Id == id)
            .Select(c => new CompetitionPreviewDALDTO()
            {
                Id = c.Id,
                Name = c.Name
            })
            .FirstAsync();
    }

    public async Task<CompetitionTableDALDTO> GetTableForUser(Guid id, Guid userId)
    {
        return await DbSet
            .Where(c => c.Id == id)
            .Select(c => new CompetitionTableDALDTO()
            {
                Name = c.Name,
                HasEnded = c.HasEnded,
                UserIsHost = c.CompetitionUsers!.First(cu => cu.UserId == userId).IsHost,
                CompetitionUsers = c.CompetitionUsers!
                    .OrderByDescending(cu => cu.UserId == userId)
                    .ThenBy(cu => cu.CreatedDT)
                    .Select(cu => new CompetitionUserDALDTO()
                    {
                        Id = cu.Id,
                        Name = cu.User!.UserName!
                    }),
                CompetitionStages = c.CompetitionStages!.OrderBy(cs => cs.CreatedDT).Select(cs => new CompetitionStageDALDTO()
                {
                    Id = cs.Id,
                    Name = cs.Name,
                    PointsOnCorrectScore = cs.PointsOnCorrectScore,
                    PointsOnCorrectScoreDifference = cs.PointsOnCorrectScoreDifference,
                    PointsOnCorrectResult = cs.PointsOnCorrectResult,
                    GameGroups = cs.GameGroups!.OrderBy(gg => gg.CreatedDT).Select(gg => new GameGroupDALDTO()
                    {
                        Id = gg.Id,
                        Name = gg.Name,
                        Games = gg.Games!.OrderBy(g => g.CreatedDT).Select(g => new GameDALDTO()
                        {
                            Id = g.Id,
                            TeamOneName = g.TeamOneName,
                            TeamTwoName = g.TeamTwoName,
                            TeamOneScore = g.TeamOneScore,
                            TeamTwoScore = g.TeamTwoScore,
                            PredictionDeadlineDT = g.PredictionDeadlineDT,
                            Predictions = g.Predictions!.Select(p => new PredictionDALDTO()
                            {
                                CompetitionUserId = p.CompetitionUserId,
                                TeamOneScore = p.TeamOneScore,
                                TeamTwoScore = p.TeamTwoScore
                            })
                        })
                    })
                })
            })
            .FirstAsync();
    }
}
