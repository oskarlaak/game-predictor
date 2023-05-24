using BLL.DTO.Competition;
using BLL.Interfaces.Base;

namespace BLL.Interfaces.App.Services;

public interface ICompetitionService : IBaseService
{
    Task<IEnumerable<CompetitionBLLDTO>> GetAll(Guid userId);
}
