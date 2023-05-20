using BLL.Interfaces.App.Services;
using DAL.Interfaces.App;

namespace BLL.App.Services;

public class GameGroupService : AppBaseService, IGameGroupService
{
    public GameGroupService(IAppUOW uow) : base(uow)
    {
    }
}
