using DAL.Interfaces.Base;
using Domain.App;

namespace DAL.Interfaces.App.Repos;

public interface IGameRepo : IBaseRepo<Game>
{
    Task<bool> CompetitionOfGameDoesNotHaveCompetitionUser(Guid id, Guid competitionUserId);
    
    Task<bool> GameIsPredictable(Guid id);
    
    Task<bool> GameIsNotPredictable(Guid id);
}
