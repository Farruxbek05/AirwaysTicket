using Airways.Core.Entity;
using System.IdentityModel.Tokens.Jwt;

namespace Airways.DataAccess.Authentication
{
    public interface IJwtTokenHandler
    {
        JwtSecurityToken GenerateAccesToken(UserForCreationDTO user);
        JwtSecurityToken GenerateAccesToken(User user);
        string GenerateRefreshToken();
    }
}
