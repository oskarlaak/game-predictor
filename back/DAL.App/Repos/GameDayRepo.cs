using DAL.Interfaces.App.Repos;
using Domain.App;

namespace DAL.App.Repos;

public class GameDayRepo : AppBaseRepo<GameDay>, IGameDayRepo
{
    public GameDayRepo(AppDbContext ctx) : base(ctx)
    {
    }
}
