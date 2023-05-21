using BLL.DTO.Identity;
using Public.DTO.Identity;

namespace WebApp.Mappers;

public class IdentityMapper
{
    public JwtDTO Map(JwtBLLDTO dto)
    {
        return new JwtDTO()
        {
            Token = dto.Token,
            RefreshToken = dto.RefreshToken
        };
    }

    public JwtBLLDTO Map(JwtDTO dto)
    {
        return new JwtBLLDTO()
        {
            Token = dto.Token,
            RefreshToken = dto.RefreshToken
        };
    }
    
    public RegisterBLLDTO Map(RegisterDTO dto)
    {
        return new RegisterBLLDTO()
        {
            Username = dto.Username,
            Email = dto.Email,
            Password = dto.Password,
            ConfirmPassword = dto.ConfirmPassword
        };
    }

    public LoginBLLDTO Map(LoginDTO dto)
    {
        return new LoginBLLDTO()
        {
            Email = dto.Email,
            Password = dto.Password
        };
    }
}
