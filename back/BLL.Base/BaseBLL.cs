using BLL.Interfaces.Base;
using DAL.Interfaces.Base;

namespace BLL.Base;

public abstract class BaseBLL<TUOW> : IBaseBLL
    where TUOW : IBaseUOW
{
    protected TUOW Uow { get; set; }

    protected BaseBLL(TUOW uow)
    {
        Uow = uow;
    }
    
    public async Task SaveChanges()
    {
        await Uow.SaveChanges();
    }
}
