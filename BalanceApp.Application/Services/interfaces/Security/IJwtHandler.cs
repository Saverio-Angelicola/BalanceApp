using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace BalanceApp.Application.Services.interfaces.Security
{
    public interface IJwtHandler
    {
        JwtSecurityToken ReadJwtToken(string token);
        string WriteToken(SecurityToken token);
    }
}
