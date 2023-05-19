using BLL.Interfaces.App.Services;
using DAL.Interfaces.App;

namespace BLL.App.Services;

public class GameDayService : AppBaseService, IGameDayService
{
    public GameDayService(IAppUOW uow) : base(uow)
    {
    }
}
