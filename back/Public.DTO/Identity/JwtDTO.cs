namespace Public.DTO.Identity;

public class JwtDTO
{
    public string Token { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
}
