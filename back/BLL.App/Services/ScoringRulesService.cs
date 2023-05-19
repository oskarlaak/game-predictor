using BLL.Interfaces.App.Services;
using DAL.Interfaces.App;

namespace BLL.App.Services;

public class ScoringRulesService : AppBaseService, IScoringRulesService
{
    public ScoringRulesService(IAppUOW uow) : base(uow)
    {
    }
}
