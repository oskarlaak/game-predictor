using BLL.DTO.GameGroup;

namespace BLL.DTO.CompetitionStage;

public class CompetitionStageBLLDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string ScoringRulesName { get; set; } = default!;
    public IEnumerable<GameGroupBLLDTO> GameGroups { get; set; } = default!;
}
