using DAL.Interfaces.App.Repos;
using Domain.App;

namespace DAL.App.Repos;

public class ScoringRulesRepo : AppBaseRepo<ScoringRules>, IScoringRulesRepo
{
    public ScoringRulesRepo(AppDbContext ctx) : base(ctx)
    {
    }
}
