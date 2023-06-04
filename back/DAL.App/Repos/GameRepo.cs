using DAL.Interfaces.App.Repos;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.Repos;

public class GameRepo : AppBaseRepo<Game>, IGameRepo
{
    public GameRepo(AppDbContext ctx) : base(ctx)
    {
    }

    public async Task<bool> CompetitionOfGameDoesNotHaveCompetitionUser(Guid id, Guid competitionUserId)
    {
        return await DbSet
            .AnyAsync(g =>
                g.Id == id &&
                g.GameGroup!.CompetitionStage!.Competition!.CompetitionUsers!.All(cu => cu.Id != competitionUserId)
            );
    }

    public async Task<bool> GameIsPredictable(Guid id)
    {
        return await DbSet
            .AnyAsync(g =>
                g.Id == id &&
                g.PredictionDeadlineDT > DateTime.UtcNow
            );
    }

    public async Task<bool> GameIsNotPredictable(Guid id)
    {
        return !await GameIsPredictable(id);
    }
}
