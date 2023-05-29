using DAL.DTO.Competition;
using DAL.Interfaces.Base;
using Domain.App;

namespace DAL.Interfaces.App.Repos;

public interface ICompetitionRepo : IBaseRepo<Competition>
{
    Task<IEnumerable<CompetitionDALDTO>> GetAll(Guid userId);

    Task<CompetitionDALDTO?> GetById(Guid id, Guid userId);
    
    Task<CompetitionTableDALDTO?> GetByIdTable(Guid id, Guid userId);
}
