using BalanceApp.Application.Services.interfaces.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Services.implementations.Security
{
    public class JwtHandler : JwtSecurityTokenHandler, IJwtHandler
    {
    }
}
