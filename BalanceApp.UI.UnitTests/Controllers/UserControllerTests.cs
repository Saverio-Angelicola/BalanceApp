using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Entities;
using BalanceApp.UI.Controllers;
using Moq;
using System;

namespace BalanceApp.UI.UnitTests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> userServiceStub;
        private readonly Mock<ITokenService> tokenServiceStub;
        private readonly UserController controller;

        public UserControllerTests()
        {
            userServiceStub = new();
            tokenServiceStub = new();
            controller = new(userServiceStub.Object, tokenServiceStub.Object);
        }

        /*  [Fact]
          public async Task DeleteUser_WithCorrectUser_ReturnsOk()
          {
              //Arrange
              User expected = CreateRandomUser();
              userServiceStub.Setup(service=>service.DeleteUser(It.IsAny<string>())).ReturnsAsync(expected);
              //Act
              var result = await controller.DeleteUser();
              //Assert
              result.Should().BeOfType<OkObjectResult>();
          } */

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid, guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString());
        }
    }
}
