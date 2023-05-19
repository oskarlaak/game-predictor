using DAL.Interfaces.App.Repos;
using Domain.App.Identity;

namespace DAL.App.Repos;

public class RefreshTokenRepo : AppBaseRepo<RefreshToken>, IRefreshTokenRepo
{
    public RefreshTokenRepo(AppDbContext ctx) : base(ctx)
    {
    }
}
