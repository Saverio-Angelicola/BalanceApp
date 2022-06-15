using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Security;
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
        private readonly IJwtHandler jwtHandler;
        public TokenService(IConfiguration configuration, IJwtHandler jwtHandler)
        {
            _configuration = configuration;
            this.jwtHandler = jwtHandler;
        }
        public string CreateJwtToken(User user,string withingsToken)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.SerialNumber, withingsToken),
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken token = new(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

            string jwt = jwtHandler.WriteToken(token);

            return jwt;
        }

        public string GetEmailFromJwtToken(string bearerToken)
        {
            string token = bearerToken.Remove(0, 7);
            string email = jwtHandler.ReadJwtToken(token).Payload.Claims.ElementAt(0).Value;
            return email;
        }

        public string GetWithingsTokenFromJwtToken(string bearerToken)
        {
            string token = bearerToken.Remove(0, 7);
            string withingsToken = jwtHandler.ReadJwtToken(token).Payload.Claims.ElementAt(2).Value;
            return withingsToken;
        }
    }
}
