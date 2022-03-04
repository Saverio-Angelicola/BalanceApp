using BalanceApp.Application.Dtos.Auth;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BalanceApp.Application.Services.implementations.Auth
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
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken token = new(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

            string jwt = new JwtSecurityTokenHandler().WriteToken(token);
            TokenDto tokenDto = new(jwt);

            return tokenDto;
        }

        public string GetUsernameFromJwtToken(string bearerToken)
        {
            string token = bearerToken.Remove(0, 7);
            string username = new JwtSecurityTokenHandler().ReadJwtToken(token).Payload.Claims.ElementAt(0).Value; ;
            return username;
        }
    }
}
