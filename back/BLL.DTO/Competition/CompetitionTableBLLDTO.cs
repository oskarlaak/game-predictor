using BLL.DTO.CompetitionStage;
using BLL.DTO.CompetitionUser;

namespace BLL.DTO.Competition;

public class CompetitionTableBLLDTO
{
    public IEnumerable<CompetitionUserBLLDTO> CompetitionUsers { get; set; } = default!;
    public IEnumerable<CompetitionStageBLLDTO> CompetitionStages { get; set; } = default!;
}
