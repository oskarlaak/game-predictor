using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BLL.DTO.Identity;
using BLL.Interfaces.App.Services;
using DAL.Interfaces.App;
using Domain.App;
using Helpers.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BLL.App.Services;

public class IdentityService : AppBaseService, IIdentityService
{
    private IConfiguration _config = default!;
    private UserManager<User> _userManager = default!;
    private SignInManager<User> _signInManager = default!;

    public IdentityService(IAppUOW uow) : base(uow)
    {
    }

    public void Setup(
        IConfiguration config,
        UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        _config = config;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    private async Task<JwtBLLDTO> NewJwt(User user)
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
        
        return new JwtBLLDTO()
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

    public async Task<JwtBLLDTO> Register(RegisterBLLDTO register)
    {
        if (InputValidationHelpers.AnyEmptyOrWhiteSpace(
                register.Username,
                register.Email,
                register.Password))
        {
            throw new ArgumentException("Empty Username, Email or Password");
        }

        if (register.Password != register.ConfirmPassword)
        {
            throw new ArgumentException("Password doesn't match with ConfirmPassword");
        }

        if (await _userManager.FindByEmailAsync(register.Email) != null)
        {
            throw new ArgumentException("User with Email already exists");
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
            throw new ArgumentException(result.Errors.First().Description);
        }

        user = (await _userManager.FindByEmailAsync(user.Email))!;

        return await NewJwt(user);
    }

    public async Task<JwtBLLDTO> Login(LoginBLLDTO login)
    {
        if (InputValidationHelpers.AnyEmptyOrWhiteSpace(login.Email, login.Password))
        {
            throw new ArgumentException("Empty Email or Password");
        }

        User? user = await _userManager.FindByEmailAsync(login.Email);
        if (user == null)
        {
            throw new ArgumentException("User with Email doesn't exist");
        }

        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
        if (!result.Succeeded)
        {
            throw new ArgumentException("Wrong Password");
        }

        SetRefreshToken(user);

        return await NewJwt(user);
    }

    public async Task Logout(Guid userId)
    {
        User? user = await Uow.UserRepo.GetById(userId);

        if (user == null)
        {
            throw new ArgumentException("Could not find user");
        }

        user.RefreshTokenExpirationDT = DateTime.UtcNow;
    }

    public async Task<JwtBLLDTO> RefreshJwt(JwtBLLDTO jwt)
    {
        if (!IdentityHelpers.IsValidToken(
                jwt.Token,
                _config["Jwt:Key"]!,
                _config["Jwt:Issuer"]!,
                _config["Jwt:Audience"]!))
        {
            throw new ArgumentException("Invalid token");
        }

        List<Claim> claims = new JwtSecurityTokenHandler().ReadJwtToken(jwt.Token).Claims.ToList();

        string email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)!.Value;

        User user = (await _userManager.FindByEmailAsync(email))!;

        if (user.RefreshToken != jwt.RefreshToken)
        {
            throw new ArgumentException("User RefreshToken doesn't match");
        }

        if (user.RefreshTokenExpirationDT < DateTime.UtcNow)
        {
            throw new ArgumentException("User RefreshToken has expired");
        }

        SetRefreshToken(user);

        return await NewJwt(user);
    }
}
