using BLL.Interfaces.App.Services;
using DAL.Interfaces.App;

namespace BLL.App.Services;

public class IdentityService : AppBaseService, IIdentityService
{
    public IdentityService(IAppUOW uow) : base(uow)
    {
    }
}
