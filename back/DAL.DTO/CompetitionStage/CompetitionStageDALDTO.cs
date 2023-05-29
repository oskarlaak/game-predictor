using DAL.DTO.GameGroup;

namespace DAL.DTO.CompetitionStage;

public class CompetitionStageDALDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string ScoringRulesName { get; set; } = default!;
    public int PointsOnCorrectScore { get; set; }
    public int PointsOnCorrectScoreDifference { get; set; }
    public int PointsOnCorrectResult { get; set; }
    public int PointsMultiplier { get; set; }
    public IEnumerable<GameGroupDALDTO> GameGroups { get; set; } = default!;
}
