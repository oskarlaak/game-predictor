using DAL.DTO.CompetitionStage;
using DAL.DTO.CompetitionUser;

namespace DAL.DTO.Competition;

public class CompetitionTableDALDTO
{
    public IEnumerable<CompetitionUserDALDTO> CompetitionUsers { get; set; } = default!;
    public IEnumerable<CompetitionStageDALDTO> CompetitionStages { get; set; } = default!;
}
