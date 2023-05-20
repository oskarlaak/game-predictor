using Public.DTO.Game;

namespace Public.DTO.GameGroup;

public class GameGroupDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public IEnumerable<GameDTO> Games { get; set; } = default!;
}
