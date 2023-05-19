using BLL.Base;
using DAL.Interfaces.App;

namespace BLL.App;

public abstract class AppBaseService : BaseService<IAppUOW>
{
    protected AppBaseService(IAppUOW uow) : base(uow)
    {
    }
}
