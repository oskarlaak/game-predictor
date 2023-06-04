using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DAL.Interfaces.App;
using Domain.App;
using Helpers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Public.DTO;
using Public.DTO.UserAuth;
using WebApp.Helpers;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace WebApp.Api;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserAuthController : ControllerBase
{
    private readonly IAppUOW _uow;
    private readonly IConfiguration _config;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserAuthController(
        IAppUOW uow,
        IConfiguration config,
        UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        _uow = uow;
        _config = config;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    private async Task<JwtDTO> NewJwt(User user)
    {
        ClaimsPrincipal claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user);

        if (!claimsPrincipal.Claims.Any())
        {
            throw new ArgumentException("Could not get ClaimsPrincipal");
        }

        string token = IdentityHelpers.GenerateJwt(
            claimsPrincipal.Claims,
            _config["Jwt:Key"]!,
            _config["Jwt:Issuer"]!,
            _config["Jwt:Audience"]!,
            int.Parse(_config["Jwt:TokenExpiresInSeconds"]!)
        );
        
        return new JwtDTO()
        {
            Token = token,
            RefreshToken = user.RefreshToken
        };
    }

    private void SetRefreshToken(User user)
    {
        user.RefreshToken = Guid.NewGuid().ToString();
        user.RefreshTokenExpirationDT = DateTime.UtcNow.AddDays(int.Parse(_config["Jwt:RefreshTokenExpiresInDays"]!));
    }
    
    [HttpPost]
    public async Task<ActionResult<JwtDTO>> Register([FromBody] RegisterDTO register)
    {
        if (InputValidationHelpers.AnyEmptyOrWhiteSpace(
                register.Username,
                register.Email,
                register.Password))
        {
            return ResponseHelpers.Error("Empty Username, Email or Password");
        }

        if (register.Password != register.ConfirmPassword)
        {
            return ResponseHelpers.Error("Password doesn't match with ConfirmPassword");
        }

        if (await _userManager.FindByEmailAsync(register.Email) != null)
        {
            return ResponseHelpers.Error("User with Email already exists");
        }

        User user = new()
        {
            UserName = register.Username,
            Email = register.Email,
        };
        SetRefreshToken(user);

        IdentityResult result = await _userManager.CreateAsync(user, register.Password);
        if (!result.Succeeded)
        {
            return ResponseHelpers.Error(result.Errors.First().Description);
        }
        
        user = (await _userManager.FindByEmailAsync(user.Email))!;

        JwtDTO newJwt = await NewJwt(user);
        
        await _uow.SaveChanges();
        
        return Ok(newJwt);
    }

    [HttpPost]
    public async Task<ActionResult<JwtDTO>> Login([FromBody] LoginDTO login)
    {
        if (InputValidationHelpers.AnyEmptyOrWhiteSpace(login.Email, login.Password))
        {
            return ResponseHelpers.Error("Empty Email or Password");
        }

        User? user = await _userManager.FindByEmailAsync(login.Email);
        if (user == null)
        {
            return ResponseHelpers.Error("User with Email doesn't exist");
        }

        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
        if (!result.Succeeded)
        {
            return ResponseHelpers.Error("Wrong Password");
        }

        SetRefreshToken(user);

        JwtDTO newJwt = await NewJwt(user);
        
        await _uow.SaveChanges();

        return Ok(newJwt);
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult<SuccessDTO>> Logout()
    {
        if (await _uow.UserRepo.DoesNotHaveEntity(User.Id()))
        {
            return ResponseHelpers.Error("Could not find user");
        }
        
        User user = await _uow.UserRepo.Get(User.Id());

        user.RefreshTokenExpirationDT = DateTime.UtcNow;

        await _uow.SaveChanges();

        return ResponseHelpers.Success("Logged out");
    }

    [HttpPost]
    public async Task<ActionResult<JwtDTO>> RefreshJwt([FromBody] JwtDTO jwt)
    {
        if (!IdentityHelpers.IsValidToken(
                jwt.Token,
                _config["Jwt:Key"]!,
                _config["Jwt:Issuer"]!,
                _config["Jwt:Audience"]!))
        {
            return ResponseHelpers.Error("Invalid token");
        }

        List<Claim> claims = new JwtSecurityTokenHandler().ReadJwtToken(jwt.Token).Claims.ToList();

        string email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)!.Value;

        User user = (await _userManager.FindByEmailAsync(email))!;

        if (user.RefreshToken != jwt.RefreshToken)
        {
            return ResponseHelpers.Error("User RefreshToken doesn't match");
        }

        if (user.RefreshTokenExpirationDT < DateTime.UtcNow)
        {
            return ResponseHelpers.Error("User RefreshToken has expired");
        }

        SetRefreshToken(user);

        JwtDTO newJwt = await NewJwt(user);
        
        await _uow.SaveChanges();
        
        return Ok(newJwt);
    }
}
