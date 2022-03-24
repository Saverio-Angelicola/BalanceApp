using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Services.interfaces.Security
{
    public interface IJwtHandler
    {
        JwtSecurityToken ReadJwtToken(string token);
        string WriteToken(SecurityToken token);
    }
}
