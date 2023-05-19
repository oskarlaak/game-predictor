using BLL.Interfaces.App.Services;
using DAL.Interfaces.App;

namespace BLL.App.Services;

public class CompetitionTypeService : AppBaseService, ICompetitionTypeService
{
    public CompetitionTypeService(IAppUOW uow) : base(uow)
    {
    }
}
