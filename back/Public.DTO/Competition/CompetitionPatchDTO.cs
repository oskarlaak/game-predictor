namespace Public.DTO.Competition;

public class CompetitionPatchDTO
{
    public string Name { get; set; } = default!;
    public bool HasEnded { get; set; }
}
