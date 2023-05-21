using BLL.DTO.Identity;
using BLL.Interfaces.App;
using Domain.App;
using Helpers.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Public.DTO;
using Public.DTO.Identity;
using WebApp.Helpers;
using WebApp.Mappers;

namespace WebApp.Api;

[ApiController]
[Route("api/[controller]/[action]")]
public class IdentityController : ControllerBase
{
    private readonly IAppBLL _bll;
    private readonly IdentityMapper _mapper;

    public IdentityController(
        IAppBLL bll,
        IConfiguration config,
        UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        _bll = bll;
        _bll.IdentityService.Setup(
            config,
            userManager,
            signInManager
        );
        _mapper = new();
    }

    [HttpPost]
    public async Task<ActionResult<JwtDTO>> Register([FromBody] RegisterDTO register)
    {
        RegisterBLLDTO registerBll = _mapper.Map(register);

        JwtBLLDTO jwtBll;
        try
        { 
            jwtBll = await _bll.IdentityService.Register(registerBll);
            
        }
        catch (ArgumentException e)
        {
            return ResponseHelpers.ErrorResponse(e.Message);
        }
        
        await _bll.SaveChanges();

        return Ok(_mapper.Map(jwtBll));
    }

    [HttpPost]
    public async Task<ActionResult<JwtDTO>> Login([FromBody] LoginDTO login)
    {
        LoginBLLDTO loginBll = _mapper.Map(login);

        JwtBLLDTO jwtBll;
        try
        {
            jwtBll = await _bll.IdentityService.Login(loginBll);
        }
        catch (ArgumentException e)
        {
            return ResponseHelpers.ErrorResponse(e.Message);
        }
        
        await _bll.SaveChanges();

        return Ok(_mapper.Map(jwtBll));
    }

    [HttpPost]
    public async Task<ActionResult<SuccessDTO>> Logout()
    {
        try
        {
            await _bll.IdentityService.Logout(User.GetId());
        }
        catch (ArgumentException e)
        {
            return ResponseHelpers.ErrorResponse(e.Message);
        }

        await _bll.SaveChanges();

        return ResponseHelpers.SuccessResponse("Logged out");
    }

    [HttpPost]
    public async Task<ActionResult<JwtDTO>> RefreshJwt([FromBody] JwtDTO jwt)
    {
        JwtBLLDTO jwtBll = _mapper.Map(jwt);

        try
        {
            jwtBll = await _bll.IdentityService.RefreshJwt(jwtBll);
        }
        catch (ArgumentException e)
        {
            return ResponseHelpers.ErrorResponse(e.Message);
        }

        await _bll.SaveChanges();

        return Ok(_mapper.Map(jwtBll));
    }
}
