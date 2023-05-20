using Public.DTO.GameGroup;

namespace Public.DTO.CompetitionStage;

public class CompetitionStageDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string ScoringRulesName { get; set; } = default!;
    public IEnumerable<GameGroupDTO> GameGroups { get; set; } = default!;
}
