using Public.DTO.CompetitionStage;
using Public.DTO.CompetitionUser;

namespace Public.DTO.Competition;

public class CompetitionTableDTO
{
    public IEnumerable<CompetitionStageDTO> CompetitionStages { get; set; } = default!;
    public IEnumerable<CompetitionUserDTO> CompetitionUsers { get; set; } = default!;
}
