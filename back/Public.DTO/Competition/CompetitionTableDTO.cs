using Public.DTO.CompetitionStage;
using Public.DTO.CompetitionUser;

namespace Public.DTO.Competition;

public class CompetitionTableDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public bool HasEnded { get; set; }
    public bool UserIsHost { get; set; }
    public IEnumerable<CompetitionUserDTO> CompetitionUsers { get; set; } = default!;
    public IEnumerable<CompetitionStageDTO> CompetitionStages { get; set; } = default!;
}
