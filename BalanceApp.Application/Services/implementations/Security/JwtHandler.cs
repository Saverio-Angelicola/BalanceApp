using BalanceApp.Application.Services.interfaces.Security;
using System.IdentityModel.Tokens.Jwt;

namespace BalanceApp.Application.Services.implementations.Security
{
    public class JwtHandler : JwtSecurityTokenHandler, IJwtHandler
    {
    }
}
