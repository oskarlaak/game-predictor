using DAL.DTO.Prediction;
using DAL.Interfaces.Base;
using Domain.App;

namespace DAL.Interfaces.App.Repos;

public interface IPredictionRepo : IBaseRepo<Prediction>
{
    Task<bool> PredictionByCompetitionUserForGameAlreadyExists(Guid competitionUserId, Guid gameId);
    
    Task<IEnumerable<PredictionDALDTO>> GetAllForGame(Guid gameId);
}
