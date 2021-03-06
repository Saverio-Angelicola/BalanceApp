using BalanceApp.Application.Dtos.Auth;
using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Providers;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.implementations.Auth;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BalanceApp.Application.UnitTests.Auth
{
    public class AuthServiceTests
    {
        private readonly Mock<ITokenService> tokenServiceStub;
        private readonly Mock<IUserFetcherService> userFetcherServiceStub;
        private readonly Mock<IPasswordHasher<User>> passwordHasherStub;
        private readonly Mock<IUserRepository> repoStub;
        private readonly Mock<IWithingsProvider> providerStub;
        private readonly AuthService authService;

        public AuthServiceTests()
        {
            tokenServiceStub = new();
            userFetcherServiceStub = new();
            passwordHasherStub = new();
            repoStub = new();
            providerStub = new();
            authService = new(tokenServiceStub.Object, userFetcherServiceStub.Object, passwordHasherStub.Object, providerStub.Object, repoStub.Object);
        }

        [Fact]
        public async Task Login_WithCorrectPassword_ReturnTokenDto()
        {
            //Arrange
            string expected = "jsonwebtoken";
            User fakeUser = CreateRandomUser();
            LoginDto fakeDto = new();
            userFetcherServiceStub.Setup(service => service.GetUserByEmail(It.IsAny<string>())).ReturnsAsync(fakeUser);
            passwordHasherStub.Setup(service => service.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Success);
            tokenServiceStub.Setup(service => service.CreateJwtToken(It.IsAny<User>(), It.IsAny<string>())).Returns(expected);
            //Act
            var result = await authService.Login(fakeDto);
            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public async Task Login_WithIncorrectPassword_ThrowsUnauthorizedAuthenticationException()
        {
            //Arrange
            User fakeUser = CreateRandomUser();
            LoginDto fakeDto = new();
            userFetcherServiceStub.Setup(service => service.GetUserByEmail(It.IsAny<string>())).ReturnsAsync(fakeUser);
            passwordHasherStub.Setup(service => service.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Failed);
            //Act & Assert
            await Assert.ThrowsAsync<UnauthorizedAuthenticationException>(() => authService.Login(fakeDto));
        }

        [Fact]
        public async Task Login_WithIncorrectUser_ThrowsUnauthorizedAuthenticationException()
        {
            //Arrange
            LoginDto fakeDto = new();
            userFetcherServiceStub.Setup(service => service.GetUserByEmail(It.IsAny<string>())).ThrowsAsync(new Exception());
            //Act & Assert
            await Assert.ThrowsAsync<UnauthorizedAuthenticationException>(() => authService.Login(fakeDto));
        }

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid, guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString(), "1/1/2000", DateTime.UtcNow);
        }
    }
}
