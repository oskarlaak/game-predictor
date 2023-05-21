using Domain.Interfaces.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.App;

public class User : IdentityUser<Guid>, IBaseDomainEntity
{
    public string RefreshToken { get; set; } = default!;
    public DateTime RefreshTokenExpirationDT { get; set; }

    public ICollection<CompetitionUser>? CompetitionUsers { get; set; }
}
