using BLL.DTO.Competition;
using BLL.Interfaces.App;
using Helpers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Public.DTO.Competition;
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
        IEnumerable<CompetitionBLLDTO> competitionsBll = await _bll.CompetitionService.GetAll(User.GetId());
        
        IEnumerable<CompetitionDTO> competitions = competitionsBll.Select(c => _mapper.Map(c));

        return Ok(competitions);
    }
}
