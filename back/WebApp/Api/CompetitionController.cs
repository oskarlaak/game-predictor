using BLL.DTO.Competition;
using BLL.Interfaces.App;
using Helpers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Public.DTO.Competition;
using WebApp.Helpers;
using WebApp.Mappers;

namespace WebApp.Api;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CompetitionController : ControllerBase
{
    private readonly IAppBLL _bll;
    private readonly CompetitionMapper _mapper;

    public CompetitionController(IAppBLL bll)
    {
        _bll = bll;
        _mapper = new();
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompetitionDTO>>> GetAll()
    {
        IEnumerable<CompetitionBLLDTO> competitions = await _bll.CompetitionService.GetAll(User.GetId());
        
        return Ok(competitions.Select(c => _mapper.Map(c)));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<CompetitionDTO>>> Get(Guid id)
    {
        CompetitionBLLDTO competition;

        try
        {
            competition = await _bll.CompetitionService.GetById(id, User.GetId());
        }
        catch (ArgumentException e)
        {
            return ResponseHelpers.ErrorResponse(e.Message);
        }

        return Ok(_mapper.Map(competition));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CompetitionTableDTO>> GetTable(Guid id)
    {
        CompetitionTableBLLDTO competitionTable;
        
        try
        {
            competitionTable = await _bll.CompetitionService.GetByIdTable(id, User.GetId());
        }
        catch (ArgumentException e)
        {
            return ResponseHelpers.ErrorResponse(e.Message);
        }

        return Ok(_mapper.Map(competitionTable));
    }
}
