using System.IdentityModel.Tokens.Jwt;

namespace Airways.DataAccess.Authentication
{
    public interface IJwtTokenHandler
    {
        JwtSecurityToken GenerateAccesToken(UserForCreationDTO user);
        string GenerateRefreshToken();
    }
}
