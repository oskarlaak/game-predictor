using BLL.DTO.Competition;
using Public.DTO.Competition;

namespace WebApp.Mappers;

public class CompetitionMapper
{
    public CompetitionDTO Map(CompetitionBLLDTO dto)
    {
        return new CompetitionDTO()
        {
            Id = dto.Id,
            Name = dto.Name,
            Type = dto.Type,
            HasEnded = dto.HasEnded,
            UserIsHost = dto.UserIsHost,
            ActionCount = dto.ActionCount
        };
    }
}
