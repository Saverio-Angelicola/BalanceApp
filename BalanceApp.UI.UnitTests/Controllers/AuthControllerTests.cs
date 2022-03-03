using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Entities;
using BalanceApp.UI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using BalanceApp.Application.Dtos.Auth;
using BalanceApp.Application.Dtos.Users;
using Xunit;

namespace BalanceApp.UI.UnitTests.Controllers
{
    public class AuthControllerTests
    {
        private readonly Mock<IUserService> userServiceStub;
        private readonly Mock<IAuthService> authServiceStub;
        private readonly Mock<ITokenService> tokenServiceStub;
        private readonly AuthController authController;
        public AuthControllerTests()
        {
            userServiceStub = new();
            authServiceStub = new();
            tokenServiceStub = new();
            authController = new(userServiceStub.Object, authServiceStub.Object, tokenServiceStub.Object);
        }

        [Fact]
        public async Task Register_WithUserDto_ReturnsOk()
        {
            //Arrange
            User expected = CreateRandomUser();
            userServiceStub.Setup(service => service.CreateUser(It.IsAny<CreateUserDto>())).ReturnsAsync(expected);
            //Act
            var result = await authController.Register(It.IsAny<CreateUserDto>()) as OkObjectResult;
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task Register_WithUserDto_ReturnsUser()
        {
            //Arrange
            User expected = CreateRandomUser();
            userServiceStub.Setup(service => service.CreateUser(It.IsAny<CreateUserDto>())).ReturnsAsync(expected);
            //Act
            var result = await authController.Register(It.IsAny<CreateUserDto>()) as OkObjectResult;
            //Assert
            result?.Value.Should().BeEquivalentTo(expected, options=>options.ComparingByMembers<User>());
        }

        [Fact]
        public async Task Register_WithException_ReturnsBadRequest()
        {
            //Arrange
            userServiceStub.Setup(service => service.CreateUser(It.IsAny<CreateUserDto>())).Throws(new Exception());
            //Act
            var result = await authController.Register(It.IsAny<CreateUserDto>());
            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task Login_WithCorrectUser_ReturnsOk()
        {
            //Arrange
            TokenDto expected  = CreateRandomTokenDto();
            authServiceStub.Setup(service => service.Login(It.IsAny<LoginDto>())).ReturnsAsync(expected);
            //Act
            var result = await authController.Login(It.IsAny<LoginDto>());
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task Login_WithCorrectUser_ReturnsTokenDto()
        {
            //Arrange
            TokenDto expected = CreateRandomTokenDto();
            authServiceStub.Setup(service => service.Login(It.IsAny<LoginDto>())).ReturnsAsync(expected);
            //Act
            var result = await authController.Login(It.IsAny<LoginDto>()) as OkObjectResult;
            //Assert
            result?.Value.Should().BeEquivalentTo(expected,options=>options.ComparingByMembers<TokenDto>());
        }

        [Fact]
        public async Task Login_WithException_ReturnsUnauthorized()
        {
            //Arrange
            authServiceStub.Setup(service => service.Login(It.IsAny<LoginDto>())).Throws(new Exception());
            //Act
            var result = await authController.Login(It.IsAny<LoginDto>());
            //Assert
            result.Should().BeOfType<UnauthorizedObjectResult>();
        }

        [Fact]
        public async Task GetProfile_WithCorrectUser_ReturnsUser()
        {
            //Arrange
            User expected = CreateRandomUser();
            userServiceStub.Setup(service => service.GetUserByUsername(It.IsAny<string>())).ReturnsAsync(expected);
            //Act
            var result = await authController.GetProfile() as OkObjectResult;
            //Assert
            result?.Value.Should().BeEquivalentTo(expected,options=>options.ComparingByMembers<User>());
        }

        [Fact]
        public async Task GetProfile_WithCorrectUser_ReturnsOk()
        {
            //Arrange
            User expected = CreateRandomUser();
            userServiceStub.Setup(service => service.GetUserByUsername(It.IsAny<string>())).ReturnsAsync(expected);
            //Act
            var result = await authController.GetProfile() as OkObjectResult;
            //Assert
            result?.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetProfile_WithException_ReturnsBadRequest()
        {
            //Arrange
            userServiceStub.Setup(service => service.GetUserByUsername(It.IsAny<string>())).Throws(new Exception());
            //Act
            var result = await authController.GetProfile();
            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid,guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString());
        }

        internal static TokenDto CreateRandomTokenDto()
        {
            return new(Guid.NewGuid().ToString());
        }
    }
}
