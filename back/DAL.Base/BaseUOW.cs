using DAL.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base;

public abstract class BaseUOW<TDbContext> : IBaseUOW
    where TDbContext : DbContext
{
    protected TDbContext Ctx { get; set; }
    
    protected BaseUOW(TDbContext ctx)
    {
        Ctx = ctx;
    }
    
    public async Task SaveChanges()
    {
        await Ctx.SaveChangesAsync();
    }
}
