namespace BLL.DTO.Identity;

public class JwtBLLDTO
{
    public string Token { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
}
