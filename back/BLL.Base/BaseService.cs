using BLL.Interfaces.Base;

namespace BLL.Base;

public abstract class BaseService<TUOW> : IBaseService
{
    protected TUOW Uow { get; set; }
    
    protected BaseService(TUOW uow)
    {
        Uow = uow;
    }
}
