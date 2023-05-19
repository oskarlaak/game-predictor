using DAL.Interfaces.App.Repos;
using Domain.App;

namespace DAL.App.Repos;

public class CompetitionStageRepo : AppBaseRepo<CompetitionStage>, ICompetitionStageRepo
{
    public CompetitionStageRepo(AppDbContext ctx) : base(ctx)
    {
    }
}
