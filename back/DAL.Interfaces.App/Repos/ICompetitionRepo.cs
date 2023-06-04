using DAL.DTO.Competition;
using DAL.Interfaces.Base;
using Domain.App;

namespace DAL.Interfaces.App.Repos;

public interface ICompetitionRepo : IBaseRepo<Competition>
{
    Task<IEnumerable<CompetitionDALDTO>> GetAllForUser(Guid userId);

    Task<CompetitionPreviewDALDTO> GetPreview(Guid id);
    
    Task<CompetitionTableDALDTO> GetTableForUser(Guid id, Guid userId);
}
