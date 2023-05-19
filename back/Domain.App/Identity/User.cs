using Domain.Interfaces.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity;

public class User : IdentityUser<Guid>, IBaseDomainEntity
{
    public ICollection<CompetitionUser>? CompetitionUsers { get; set; }
    public ICollection<RefreshToken>? RefreshTokens { get; set; }
}
