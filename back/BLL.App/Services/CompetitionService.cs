using BLL.App.Mappers;
using BLL.DTO.Competition;
using BLL.Interfaces.App.Services;
using DAL.DTO.Competition;
using DAL.Interfaces.App;

namespace BLL.App.Services;

public class CompetitionService : AppBaseService, ICompetitionService
{
    private readonly CompetitionMapperBLL _mapper;
    
    public CompetitionService(IAppUOW uow) : base(uow)
    {
        _mapper = new();
    }

    public async Task<IEnumerable<CompetitionBLLDTO>> GetAll(Guid userId)
    {
        IEnumerable<CompetitionDALDTO> competitionsDal = await Uow.CompetitionRepo.GetAll(userId);

        IEnumerable<CompetitionBLLDTO> competitions = competitionsDal.Select(c => _mapper.Map(c));

        return competitions;
    }
}
