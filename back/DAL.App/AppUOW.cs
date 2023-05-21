using DAL.App.Repos;
using DAL.Base;
using DAL.Interfaces.App;
using DAL.Interfaces.App.Repos;

namespace DAL.App;

public class AppUOW : BaseUOW<AppDbContext>, IAppUOW
{
    public AppUOW(AppDbContext ctx) : base(ctx)
    {
    }

    private IUserRepo? _userRepo;
    private ICompetitionRepo? _competitionRepo;
    private ICompetitionStageRepo? _competitionStageRepo;
    private ICompetitionTypeRepo? _competitionTypeRepo;
    private ICompetitionUserRepo? _competitionUserRepo;
    private IGameGroupRepo? _gameGroupRepo;
    private IGameRepo? _gameRepo;
    private IPredictionRepo? _predictionRepo;
    private IScoringRulesRepo? _scoringRulesRepo;
    
    public IUserRepo UserRepo => _userRepo ??= new UserRepo(Ctx);
    public ICompetitionRepo CompetitionRepo => _competitionRepo ??= new CompetitionRepo(Ctx);
    public ICompetitionStageRepo CompetitionStageRepo => _competitionStageRepo ??= new CompetitionStageRepo(Ctx);
    public ICompetitionTypeRepo CompetitionTypeRepo => _competitionTypeRepo ??= new CompetitionTypeRepo(Ctx);
    public ICompetitionUserRepo CompetitionUserRepo => _competitionUserRepo ??= new CompetitionUserRepo(Ctx);
    public IGameGroupRepo GameGroupRepo => _gameGroupRepo ??= new GameGroupRepo(Ctx);
    public IGameRepo GameRepo => _gameRepo ??= new GameRepo(Ctx);
    public IPredictionRepo PredictionRepo => _predictionRepo ??= new PredictionRepo(Ctx);
    public IScoringRulesRepo ScoringRulesRepo => _scoringRulesRepo ??= new ScoringRulesRepo(Ctx);
}
