namespace Domain.Base;

public abstract class BaseRefreshToken : BaseDomainEntity
{
    public string RefreshToken { get; set; } = Guid.NewGuid().ToString();
    public DateTime ExpirationDT { get; set; } = DateTime.UtcNow.AddDays(7);

    public string? PreviousRefreshToken { get; set; }
    public DateTime? PreviousExpirationDT { get; set; }
}
