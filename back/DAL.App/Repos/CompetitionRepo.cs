using DAL.Interfaces.App.Repos;
using Domain.App;

namespace DAL.App.Repos;

public class CompetitionRepo : AppBaseRepo<Competition>, ICompetitionRepo
{
    public CompetitionRepo(AppDbContext ctx) : base(ctx)
    {
    }
}
