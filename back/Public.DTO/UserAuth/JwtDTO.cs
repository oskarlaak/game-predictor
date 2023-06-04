namespace Public.DTO.UserAuth;

public class JwtDTO
{
    public string Token { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
}
