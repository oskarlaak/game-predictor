using Public.DTO.GameGroup;

namespace Public.DTO.CompetitionStage;

public class CompetitionStageDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public int PointsOnCorrectScore { get; set; }
    public int PointsOnCorrectScoreDifference { get; set; }
    public int PointsOnCorrectResult { get; set; }
    public IEnumerable<GameGroupDTO> GameGroups { get; set; } = default!;
}
