namespace Public.DTO.Game;

public class GameDTO
{
    public Guid Id { get; set; }
    public string TeamOneName { get; set; } = default!;
    public string TeamTwoName { get; set; } = default!;
    public int? TeamOneScore { get; set; }
    public int? TeamTwoScore { get; set; }
    public int SecondsLeftToPredict { get; set; }
}
