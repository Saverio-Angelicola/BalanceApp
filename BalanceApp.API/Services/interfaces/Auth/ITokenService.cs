using BalanceApp.API.Dtos.Auth;
using BalanceApp.API.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace BalanceApp.API.Services.interfaces.Auth
{
    public interface ITokenService
    {
        TokenDto CreateJwtToken(User user);
        JwtSecurityToken GetJwtTokenFromAuthorizationHeader(HttpContext context);
        string GetUsernameFromJwtToken(HttpContext context);
    }
}
