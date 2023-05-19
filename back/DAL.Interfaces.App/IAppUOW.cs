using DAL.Interfaces.App.Repos;
using DAL.Interfaces.Base;

namespace DAL.Interfaces.App;

public interface IAppUOW : IBaseUOW
{
    IUserRepo UserRepo { get; }
    IRefreshTokenRepo RefreshTokenRepo { get; }
    ICompetitionRepo CompetitionRepo { get; }
    ICompetitionStageRepo CompetitionStageRepo { get; }
    ICompetitionTypeRepo CompetitionTypeRepo { get; }
    ICompetitionUserRepo CompetitionUserRepo { get; }
    IGameDayRepo GameDayRepo { get; }
    IGameRepo GameRepo { get; }
    IPredictionRepo PredictionRepo { get; }
    IScoringRulesRepo ScoringRulesRepo { get; }
}
