namespace DAL.DTO.Competition;

public class CompetitionDALDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public bool HasEnded { get; set; }
    public bool UserIsHost { get; set; }
    public int ActionCount { get; set; }
}
