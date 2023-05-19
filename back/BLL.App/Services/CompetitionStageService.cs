using BLL.Interfaces.App.Services;
using DAL.Interfaces.App;

namespace BLL.App.Services;

public class CompetitionStageService : AppBaseService, ICompetitionStageService
{
    public CompetitionStageService(IAppUOW uow) : base(uow)
    {
    }
}
