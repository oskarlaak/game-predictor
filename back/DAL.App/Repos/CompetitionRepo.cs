using DAL.DTO.Competition;
using DAL.Interfaces.App.Repos;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.Repos;

public class CompetitionRepo : AppBaseRepo<Competition>, ICompetitionRepo
{
    public CompetitionRepo(AppDbContext ctx) : base(ctx)
    {
    }

    public async Task<IEnumerable<CompetitionDALDTO>> GetAll(Guid userId)
    {
        return await DbSet
            .Where(c => c.CompetitionUsers!.Any(cu => cu.UserId == userId))
            .OrderByDescending(c => c.CompetitionUsers!.First(cu => cu.UserId == userId).CreatedDT)
            .Select(c => new CompetitionDALDTO()
            {
                Id = c.Id,
                Name = c.Name,
                Type = c.CompetitionType!.Name,
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
}
