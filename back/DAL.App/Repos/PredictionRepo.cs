using DAL.DTO.Prediction;
using DAL.Interfaces.App.Repos;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.Repos;

public class PredictionRepo : AppBaseRepo<Prediction>, IPredictionRepo
{
    public PredictionRepo(AppDbContext ctx) : base(ctx)
    {
    }

    public async Task<bool> PredictionByCompetitionUserForGameAlreadyExists(Guid competitionUserId, Guid gameId)
    {
        return await DbSet
            .AnyAsync(p =>
                p.CompetitionUserId == competitionUserId &&
                p.GameId == gameId
            );
    }

    public async Task<IEnumerable<PredictionDALDTO>> GetAllForGame(Guid gameId)
    {
        return await DbSet
            .Where(p => p.GameId == gameId)
            .Select(p => new PredictionDALDTO()
            {
                CompetitionUserId = p.CompetitionUserId,
                TeamOneScore = p.TeamOneScore,
                TeamTwoScore = p.TeamTwoScore
            })
            .ToListAsync();
    }
}
