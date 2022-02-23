using BalanceApp.API.Dtos.Auth;
using BalanceApp.API.Entities;
using BalanceApp.API.Services.interfaces.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BalanceApp.API.Services.implementations.Auth
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenDto CreateJwtToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken token = new(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

            string jwt = new JwtSecurityTokenHandler().WriteToken(token);
            TokenDto tokenDto = new(jwt);

            return tokenDto;
        }

        public JwtSecurityToken GetJwtTokenFromAuthorizationHeader(HttpContext context)
        {
            string bearerToken = context.Request.Headers.Authorization;
            string token = bearerToken.Remove(0, 7);
            JwtSecurityToken jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            return jwt;
        }

        public string GetUsernameFromJwtToken(HttpContext context)
        {
            return GetJwtTokenFromAuthorizationHeader(context).Payload.Claims.ElementAt(0).Value;
        }
    }
}
