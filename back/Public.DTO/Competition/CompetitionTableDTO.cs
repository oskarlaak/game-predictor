using Public.DTO.CompetitionStage;
using Public.DTO.CompetitionUser;

namespace Public.DTO.Competition;

public class CompetitionTableDTO
{
    public IEnumerable<CompetitionUserDTO> CompetitionUsers { get; set; } = default!;
    public IEnumerable<CompetitionStageDTO> CompetitionStages { get; set; } = default!;
}
