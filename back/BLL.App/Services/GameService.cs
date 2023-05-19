using BLL.Interfaces.App.Services;
using DAL.Interfaces.App;

namespace BLL.App.Services;

public class GameService : AppBaseService, IGameService
{
    public GameService(IAppUOW uow) : base(uow)
    {
    }
}
