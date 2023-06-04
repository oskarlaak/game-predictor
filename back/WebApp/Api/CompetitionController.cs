using DAL.DTO.Competition;
using DAL.Interfaces.App;
using Domain.App;
using Helpers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Public.DTO;
using Public.DTO.Competition;
using WebApp.Helpers;
using WebApp.Mappers;

namespace WebApp.Api;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CompetitionController : ControllerBase
{
    private readonly IAppUOW _uow;
    private readonly CompetitionMapper _mapper;
    
    public CompetitionController(IAppUOW uow)
    {
        _uow = uow;
        _mapper = new();
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompetitionDTO>>> GetAll()
    {
        IEnumerable<CompetitionDALDTO> competitions = await _uow.CompetitionRepo.GetAllForUser(User.Id());
        
        return Ok(competitions.Select(c => _mapper.Map(c)));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CompetitionPreviewDTO>> GetPreview(Guid id)
    {
        if (await _uow.CompetitionRepo.DoesNotHaveEntity(id))
        {
            return ResponseHelpers.Error($"Competition with id {id} does not exist");
        }
        
        CompetitionPreviewDALDTO competition = await _uow.CompetitionRepo.GetPreview(id);

        return Ok(_mapper.Map(competition));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CompetitionTableDTO>> GetTable(Guid id)
    {
        if (await _uow.CompetitionRepo.DoesNotHaveEntity(id))
        {
            return ResponseHelpers.Error($"Competition with id {id} does not exist");
        }

        if (await _uow.CompetitionUserRepo.CompetitionDoesNotHaveUser(id, User.Id()))
        {
            return ResponseHelpers.Error("You are not part of this competition");
        }
        
        CompetitionTableDALDTO competitionTable = await _uow.CompetitionRepo.GetTableForUser(id, User.Id());
        
        return Ok(_mapper.Map(competitionTable));
    }

    [HttpPost]
    public async Task<ActionResult<CreatedDTO>> Post([FromBody] CompetitionPostDTO competition)
    {
        if (InputValidationHelpers.AnyEmptyOrWhiteSpace(competition.Name))
        {
            return ResponseHelpers.Error("Competition name is empty");
        }
        
        Competition c = new()
        {
            Name = competition.Name,
            HasEnded = false
        };

        Guid id = await _uow.CompetitionRepo.Add(c);

        CompetitionUser cu = new()
        {
            Competition = c,
            UserId = User.Id(),
            IsHost = true,
            CreatedDT = DateTime.UtcNow
        };

        await _uow.CompetitionUserRepo.Add(cu);

        await _uow.SaveChanges();

        return ResponseHelpers.Created(id);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<SuccessDTO>> Join(Guid id)
    {
        if (await _uow.CompetitionRepo.DoesNotHaveEntity(id))
        {
            return ResponseHelpers.Error($"Competition with id {id} does not exist");
        }

        if (await _uow.CompetitionUserRepo.CompetitionHasUser(id, User.Id()))
        {
            return ResponseHelpers.Error("You're already in this competition");
        }

        CompetitionUser cu = new()
        {
            CompetitionId = id,
            UserId = User.Id(),
            IsHost = false,
            CreatedDT = DateTime.UtcNow
        };

        await _uow.CompetitionUserRepo.Add(cu);

        await _uow.SaveChanges();

        return ResponseHelpers.Success("Joined competition");
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<SuccessDTO>> Patch(Guid id, [FromBody] CompetitionPatchDTO competition)
    {
        if (InputValidationHelpers.AnyEmptyOrWhiteSpace(competition.Name))
        {
            return ResponseHelpers.Error("Competition name cannot be empty");
        }

        if (await _uow.CompetitionRepo.DoesNotHaveEntity(id))
        {
            return ResponseHelpers.Error($"Competition with id {id} does not exist");
        }
        
        if (await _uow.CompetitionUserRepo.CompetitionDoesNotHaveUser(id, User.Id()))
        {
            return ResponseHelpers.Error("Cannot update competition while not being in it");
        }
        
        if (await _uow.CompetitionUserRepo.UserIsNotHostOfCompetition(User.Id(), id))
        {
            return ResponseHelpers.Error("Cannot update competition as participant");
        }

        Competition c = await _uow.CompetitionRepo.Get(id);

        c.Name = competition.Name;
        c.HasEnded = competition.HasEnded;

        await _uow.SaveChanges();

        return ResponseHelpers.Success("Competition updated");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<SuccessDTO>> Delete(Guid id)
    {
        if (await _uow.CompetitionRepo.DoesNotHaveEntity(id))
        {
            return ResponseHelpers.Error($"Competition with id {id} does not exist");
        }
        
        if (await _uow.CompetitionUserRepo.CompetitionDoesNotHaveUser(id, User.Id()))
        {
            return ResponseHelpers.Error("Cannot delete competition while not being in it");
        }
        
        if (await _uow.CompetitionUserRepo.UserIsNotHostOfCompetition(User.Id(), id))
        {
            return ResponseHelpers.Error("Cannot delete competition as participant");
        }

        await _uow.CompetitionRepo.Delete(id);

        await _uow.SaveChanges();

        return ResponseHelpers.Success("Deleted competition");
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<SuccessDTO>> Leave(Guid id)
    {
        if (await _uow.CompetitionRepo.DoesNotHaveEntity(id))
        {
            return ResponseHelpers.Error($"Competition with id {id} does not exist");
        }
        
        if (await _uow.CompetitionUserRepo.CompetitionDoesNotHaveUser(id, User.Id()))
        {
            return ResponseHelpers.Error("Cannot leave from competition while not being in it");
        }
        
        if (await _uow.CompetitionUserRepo.UserIsHostOfCompetition(User.Id(), id))
        {
            return ResponseHelpers.Error("Cannot leave competition as host");
        }

        await _uow.CompetitionUserRepo.DeleteUserFromCompetition(User.Id(), id);

        await _uow.SaveChanges();

        return ResponseHelpers.Success("Left competition");
    }
}
