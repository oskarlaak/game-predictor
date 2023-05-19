using Domain.Base;

namespace Domain.App.Identity;

public class RefreshToken : BaseRefreshToken
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
}
