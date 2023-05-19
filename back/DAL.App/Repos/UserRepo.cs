using DAL.Interfaces.App.Repos;
using Domain.App.Identity;

namespace DAL.App.Repos;

public class UserRepo : AppBaseRepo<User>, IUserRepo
{
    public UserRepo(AppDbContext ctx) : base(ctx)
    {
    }
}
