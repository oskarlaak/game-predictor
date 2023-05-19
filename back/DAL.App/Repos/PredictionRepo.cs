using DAL.Interfaces.App.Repos;
using Domain.App;

namespace DAL.App.Repos;

public class PredictionRepo : AppBaseRepo<Prediction>, IPredictionRepo
{
    public PredictionRepo(AppDbContext ctx) : base(ctx)
    {
    }
}
