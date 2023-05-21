using DAL.Interfaces.App.Repos;
using DAL.Interfaces.Base;

namespace DAL.Interfaces.App;

public interface IAppUOW : IBaseUOW
{
    IUserRepo UserRepo { get; }
    ICompetitionRepo CompetitionRepo { get; }
    ICompetitionStageRepo CompetitionStageRepo { get; }
    ICompetitionTypeRepo CompetitionTypeRepo { get; }
    ICompetitionUserRepo CompetitionUserRepo { get; }
    IGameGroupRepo GameGroupRepo { get; }
    IGameRepo GameRepo { get; }
    IPredictionRepo PredictionRepo { get; }
    IScoringRulesRepo ScoringRulesRepo { get; }
}
