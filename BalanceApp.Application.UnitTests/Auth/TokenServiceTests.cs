using BalanceApp.Application.Services.implementations.Auth;
using BalanceApp.Application.Services.interfaces.Security;
using BalanceApp.Domain.Entities;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Xunit;

namespace BalanceApp.Application.UnitTests.Auth
{
    public class TokenServiceTests
    {
        private readonly Mock<IConfiguration> configStub;
        private readonly Mock<IJwtHandler> jwtHandlerStub;
        private readonly TokenService tokenService; 

        public TokenServiceTests()
        {
            configStub = new Mock<IConfiguration>();
            jwtHandlerStub = new Mock<IJwtHandler>();
            tokenService = new TokenService(configStub.Object, jwtHandlerStub.Object);
        }

        [Fact]
        public void CreateJwtToken_WithUser_ReturnJwt()
        {
            //Arrange
            string expected = "keyforjwtauthentication";
            jwtHandlerStub.Setup(handler=>handler.WriteToken(It.IsAny<SecurityToken>())).Returns(expected);
            configStub.Setup(config => config.GetSection(It.IsAny<string>()).Value).Returns(expected);
            User fakeUser = CreateRandomUser();
            //Act
            var result = tokenService.CreateJwtToken(fakeUser);
            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void GetEmailFromJwtToken_WithBearerToken_ReturnEmail()
        {
            //Arrange
            User fakeUser = CreateRandomUser();
            string fakeJwt = "jsonwebtoken";
            List<Claim> fakeClaims = new()
            {
                new Claim(ClaimTypes.Email, fakeUser.Email)
            };
            jwtHandlerStub.Setup(service => service.ReadJwtToken(It.IsAny<string>())).Returns(new JwtSecurityToken(claims: fakeClaims));
            //Act
            var result = tokenService.GetEmailFromJwtToken(fakeJwt);
            //Assert
            result.Should().Be(fakeUser.Email);
        }

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid, guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString(), "1/1/2000", DateTime.UtcNow);
        }
    }
}
