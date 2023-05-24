using BLL.DTO.Competition;
using DAL.DTO.Competition;

namespace BLL.App.Mappers;

public class CompetitionMapperBLL
{
    public CompetitionBLLDTO Map(CompetitionDALDTO dalDto)
    {
        return new CompetitionBLLDTO()
        {
            Id = dalDto.Id,
            Name = dalDto.Name,
            Type = dalDto.Type,
            HasEnded = dalDto.HasEnded,
            UserIsHost = dalDto.UserIsHost,
            ActionCount = dalDto.ActionCount
        };
    }
}
