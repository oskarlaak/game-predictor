using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Helpers.Base;

public static class IdentityHelpers
{
    public static Guid GetId(this ClaimsPrincipal user)
    {
        return Guid.Parse(
            user.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value
        );
    }

    private static SecurityKey SecurityKey(string key)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    }
    
    public static string GenerateJwt(
        IEnumerable<Claim> claims,
        string key,
        string issuer,
        string audience,
        int expiresInSeconds)
    {
        SigningCredentials signingCredentials = new(
            SecurityKey(key),
            SecurityAlgorithms.HmacSha256
        );
        
        DateTime expirationDT = DateTime.UtcNow.AddSeconds(expiresInSeconds);
        
        JwtSecurityToken jwtSecurityToken = new(
            claims: claims,
            signingCredentials: signingCredentials,
            issuer: issuer,
            audience: audience,
            expires: expirationDT
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
    
    public static bool IsValidToken(
        string token,
        string key,
        string issuer,
        string audience)
    {
        SecurityToken validatedToken;
        try
        {
            new JwtSecurityTokenHandler().ValidateToken(
                token,
                GetValidationParameters(key, issuer, audience),
                out validatedToken
            );
        }
        catch (SecurityTokenExpiredException)
        {
            return true;
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
    
    private static TokenValidationParameters GetValidationParameters(
        string key,
        string issuer,
        string audience)
    {
        return new TokenValidationParameters()
        {
            IssuerSigningKey = SecurityKey(key),
            ValidIssuer = issuer,
            ValidAudience = audience,
            
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true
        };
    }
}
