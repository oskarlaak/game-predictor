using DAL.Interfaces.App.Repos;
using Domain.App;

namespace DAL.App.Repos;

public class GameGroupRepo : AppBaseRepo<GameGroup>, IGameGroupRepo
{
    public GameGroupRepo(AppDbContext ctx) : base(ctx)
    {
    }
}
