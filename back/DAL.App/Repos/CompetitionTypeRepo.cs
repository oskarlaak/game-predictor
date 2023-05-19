using DAL.Interfaces.App.Repos;
using Domain.App;

namespace DAL.App.Repos;

public class CompetitionTypeRepo : AppBaseRepo<CompetitionType>, ICompetitionTypeRepo
{
    public CompetitionTypeRepo(AppDbContext ctx) : base(ctx)
    {
    }
}
