using BalanceApp.API.Controllers;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BalanceApp.UI.UnitTests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserUpdaterService> userUpdaterServiceStub;
        private readonly Mock<IUserDeletionService> userDeletionServiceStub;
        private readonly Mock<ITokenService> tokenServiceStub;
        private readonly Mock<IUserFetcherService> userFetcherServiceStub;
        private readonly UserController controller;

        public UserControllerTests()
        {
            userUpdaterServiceStub = new();
            tokenServiceStub = new();
            userDeletionServiceStub = new();
            userFetcherServiceStub = new();
            controller = new(userFetcherServiceStub.Object, userUpdaterServiceStub.Object, tokenServiceStub.Object, userDeletionServiceStub.Object);
        }

          [Fact]
          public async Task DeleteUser_WithCorrectUser_ReturnsOk()
          {
              //Arrange
              User expected = CreateRandomUser();
              userDeletionServiceStub.Setup(service=>service.DeleteUser(It.IsAny<string>())).ReturnsAsync(expected);
              //Act
              var result = await controller.DeleteUser();
              //Assert
              result.Should().BeOfType<OkObjectResult>();
          }

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid, guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString(), "1/1/2000", DateTime.UtcNow);
        }
    }
}
