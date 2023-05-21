using BLL.DTO.Identity;
using BLL.Interfaces.Base;
using Domain.App;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BLL.Interfaces.App.Services;

public interface IIdentityService : IBaseService
{
    void Setup(
        IConfiguration config,
        UserManager<User> userManager,
        SignInManager<User> signInManager);

    Task<JwtBLLDTO> Register(RegisterBLLDTO register);
    
    Task<JwtBLLDTO> Login(LoginBLLDTO login);

    Task Logout(Guid userId);

    Task<JwtBLLDTO> RefreshJwt(JwtBLLDTO jwt);
}
