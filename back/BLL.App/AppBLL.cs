using BLL.App.Services;
using BLL.Base;
using BLL.Interfaces.App;
using BLL.Interfaces.App.Services;
using DAL.Interfaces.App;

namespace BLL.App;

public class AppBLL : BaseBLL<IAppUOW>, IAppBLL
{
    public AppBLL(IAppUOW uow) : base(uow)
    {
    }
    
    private IIdentityService? _identityService;
    private ICompetitionService? _competitionService;
    private ICompetitionStageService? _competitionStageService;
    private ICompetitionTypeService? _competitionTypeService;
    private IGameGroupService? _gameGroupService;
    private IGameService? _gameService;
    private IPredictionService? _predictionService;
    private IScoringRulesService? _scoringRulesService;

    public IIdentityService IdentityService => _identityService ??= new IdentityService(Uow);
    public ICompetitionService CompetitionService => _competitionService ??= new CompetitionService(Uow);
    public ICompetitionStageService CompetitionStageService => _competitionStageService ??= new CompetitionStageService(Uow);
    public ICompetitionTypeService CompetitionTypeService => _competitionTypeService ??= new CompetitionTypeService(Uow);
    public IGameGroupService GameGroupService => _gameGroupService ??= new GameGroupService(Uow);
    public IGameService GameService => _gameService ??= new GameService(Uow);
    public IPredictionService PredictionService => _predictionService ??= new PredictionService(Uow);
    public IScoringRulesService ScoringRulesService => _scoringRulesService ??= new ScoringRulesService(Uow);
}
