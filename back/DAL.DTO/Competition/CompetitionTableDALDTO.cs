using DAL.DTO.CompetitionStage;
using DAL.DTO.CompetitionUser;

namespace DAL.DTO.Competition;

public class CompetitionTableDALDTO
{
    public string Name { get; set; } = default!;
    public bool HasEnded { get; set; }
    public bool UserIsHost { get; set; }
    public IEnumerable<CompetitionUserDALDTO> CompetitionUsers { get; set; } = default!;
    public IEnumerable<CompetitionStageDALDTO> CompetitionStages { get; set; } = default!;
}
