using DAL.Interfaces.App.Repos;
using Domain.App;

namespace DAL.App.Repos;

public class GameRepo : AppBaseRepo<Game>, IGameRepo
{
    public GameRepo(AppDbContext ctx) : base(ctx)
    {
    }
}
