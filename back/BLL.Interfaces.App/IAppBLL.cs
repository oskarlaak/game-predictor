using BLL.Interfaces.App.Services;
using BLL.Interfaces.Base;

namespace BLL.Interfaces.App;

public interface IAppBLL : IBaseBLL
{
    IIdentityService IdentityService { get; }
    ICompetitionService CompetitionService { get; }
    ICompetitionStageService CompetitionStageService { get; }
    ICompetitionTypeService CompetitionTypeService { get; }
    IGameGroupService GameGroupService { get; }
    IGameService GameService { get; }
    IPredictionService PredictionService { get; }
    IScoringRulesService ScoringRulesService { get; }
}
