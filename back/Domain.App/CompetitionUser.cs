using Domain.App.Identity;
using Domain.Base;

namespace Domain.App;

public class CompetitionUser : BaseDomainEntity
{
    public Guid CompetitionId { get; set; }
    public Competition? Competition { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public bool IsHost { get; set; }

    public DateTime CreatedDT { get; set; }

    public ICollection<Prediction>? Predictions { get; set; }
}
