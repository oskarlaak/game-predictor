using DAL.Interfaces.App.Repos;
using Domain.App;

namespace DAL.App.Repos;

public class CompetitionUserRepo : AppBaseRepo<CompetitionUser>, ICompetitionUserRepo
{
    public CompetitionUserRepo(AppDbContext ctx) : base(ctx)
    {
    }
}
