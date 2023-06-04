using DAL.Interfaces.Base;
using Domain.App;

namespace DAL.Interfaces.App.Repos;

public interface ICompetitionUserRepo : IBaseRepo<CompetitionUser>
{
    Task<bool> CompetitionHasUser(Guid competitionId, Guid userId);
    
    Task<bool> CompetitionDoesNotHaveUser(Guid competitionId, Guid userId);
    
    Task<bool> UserIsHostOfCompetition(Guid userId, Guid competitionId);
    
    Task<bool> UserIsNotHostOfCompetition(Guid userId, Guid competitionId);
    
    Task DeleteUserFromCompetition(Guid userId, Guid competitionId);
    
    Task<bool> CompetitionUserDoesNotBelongToUser(Guid id, Guid userId);
}
