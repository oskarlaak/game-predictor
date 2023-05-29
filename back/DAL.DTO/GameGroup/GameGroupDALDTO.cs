using DAL.DTO.Game;

namespace DAL.DTO.GameGroup;

public class GameGroupDALDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public IEnumerable<GameDALDTO> Games { get; set; } = default!;
}
