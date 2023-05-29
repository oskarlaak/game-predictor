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
        IEnumerable<CompetitionDALDTO> competitions = await Uow.CompetitionRepo.GetAll(userId);

        return competitions.Select(c => _mapper.Map(c));
    }

    public async Task<CompetitionBLLDTO> GetById(Guid id, Guid userId)
    {
        CompetitionDALDTO? competition = await Uow.CompetitionRepo.GetById(id, userId);

        if (competition == null)
        {
            throw new ArgumentException("Competition doesn't exist or you're not in it");
        }

        return _mapper.Map(competition);
    }

    public async Task<CompetitionTableBLLDTO> GetByIdTable(Guid id, Guid userId)
    {
        CompetitionTableDALDTO? competitionTable = await Uow.CompetitionRepo.GetByIdTable(id, userId);

        if (competitionTable == null)
        {
            throw new ArgumentException("Competition doesn't exist or you're not in it");
        }

        return _mapper.Map(competitionTable);
    }
}
