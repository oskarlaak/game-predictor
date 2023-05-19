using BLL.Interfaces.App.Services;
using DAL.Interfaces.App;

namespace BLL.App.Services;

public class PredictionService : AppBaseService, IPredictionService
{
    public PredictionService(IAppUOW uow) : base(uow)
    {
    }
}
