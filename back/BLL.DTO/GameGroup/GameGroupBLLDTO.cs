using BLL.DTO.Game;

namespace BLL.DTO.GameGroup;

public class GameGroupBLLDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public IEnumerable<GameBLLDTO> Games { get; set; } = default!;
}
