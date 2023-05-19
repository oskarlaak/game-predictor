using BLL.Interfaces.App.Services;
using DAL.Interfaces.App;

namespace BLL.App.Services;

public class CompetitionService : AppBaseService, ICompetitionService
{
    public CompetitionService(IAppUOW uow) : base(uow)
    {
    }
}
