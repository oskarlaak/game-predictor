using DAL.DTO.Prediction;
using DAL.Interfaces.App;
using Domain.App;
using Helpers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Public.DTO.Prediction;
using WebApp.Helpers;
using WebApp.Mappers;

namespace WebApp.Api;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class PredictionController : ControllerBase
{
    private readonly IAppUOW _uow;
    private readonly PredictionMapper _mapper;
    
    public PredictionController(IAppUOW uow)
    {
        _uow = uow;
        _mapper = new();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<PredictionDTO>>> GetAllForGame(Guid id)
    {
        if (await _uow.GameRepo.DoesNotHaveEntity(id))
        {
            return ResponseHelpers.Error($"Game with id {id} does not exist");
        }

        if (await _uow.GameRepo.GameIsPredictable(id))
        {
            return ResponseHelpers.Error("Cannot request predictions if game is still predictable");
        }
        
        IEnumerable<PredictionDALDTO> predictions = await _uow.PredictionRepo.GetAllForGame(id);
        
        return Ok(predictions.Select(p => _mapper.Map(p)));
    }
    
    
    [HttpPost]
    public async Task<ActionResult<IEnumerable<PredictionDTO>>> Post([FromBody] PredictionPostDTO prediction)
    {
        if (InputValidationHelpers.AnyNegative(prediction.TeamOneScore, prediction.TeamTwoScore))
        {
            return ResponseHelpers.Error("Attempting to submit negative score");
        }
        
        if (await _uow.GameRepo.DoesNotHaveEntity(prediction.GameId))
        {
            return ResponseHelpers.Error($"Game with id {prediction.GameId} does not exist");
        }
        
        if (await _uow.CompetitionUserRepo.DoesNotHaveEntity(prediction.CompetitionUserId))
        {
            return ResponseHelpers.Error($"Competition user with id {prediction.CompetitionUserId} does not exist");
        }
        
        if (await _uow.GameRepo.CompetitionOfGameDoesNotHaveCompetitionUser(prediction.GameId, prediction.CompetitionUserId))
        {
            return ResponseHelpers.Error("Game does not exist in competition which competition user is part of");
        }
        
        if (await _uow.CompetitionUserRepo.CompetitionUserDoesNotBelongToUser(prediction.CompetitionUserId, User.Id()))
        {
            return ResponseHelpers.Error("Attempting to predict as someone else");
        }
        
        if (await _uow.PredictionRepo.PredictionByCompetitionUserForGameAlreadyExists(prediction.CompetitionUserId, prediction.GameId))
        {
            return ResponseHelpers.Error("Game already predicted");
        }
        
        if (await _uow.GameRepo.GameIsNotPredictable(prediction.GameId))
        {
            return ResponseHelpers.Error("Prediction deadline has expired");
        }
        
        Prediction p = new()
        {
            GameId = prediction.GameId,
            CompetitionUserId = prediction.CompetitionUserId,
            TeamOneScore = prediction.TeamOneScore,
            TeamTwoScore = prediction.TeamTwoScore
        };
        
        await _uow.PredictionRepo.Add(p);
        
        await _uow.SaveChanges();
        
        IEnumerable<PredictionDALDTO> predictions = await _uow.PredictionRepo.GetAllForGame(prediction.GameId);
        
        return Ok(predictions.Select(p => _mapper.Map(p)));
    }
}
