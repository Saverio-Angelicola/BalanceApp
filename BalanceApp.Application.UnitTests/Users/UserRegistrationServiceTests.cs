using BalanceApp.Application.Dtos.Users;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.implementations.Users;
using BalanceApp.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BalanceApp.Application.UnitTests.Users
{
    public class UserRegistrationServiceTests
    {
        private readonly Mock<IUserRepository> repository;
        private readonly Mock<IPasswordHasher<User>> hasher;
        private readonly UserRegistrationService service;

        public UserRegistrationServiceTests()
        {
            repository = new Mock<IUserRepository>();
            hasher = new();
            service = new UserRegistrationService(repository.Object, hasher.Object);
        }

        [Fact]
        public async Task RegisterUser_WithUserCreate_ReturnUser()
        {
            //Arrange
            var expected = CreateRandomUser();
            var fakeDto = new CreateUserDto(expected.Firstname,expected.Lastname,expected.Email,expected.UserPassword);
            repository.Setup(repo=>repo.Create(It.IsAny<User>())).ReturnsAsync(expected);
            hasher.Setup(service=>service.HashPassword(It.IsAny<User>(), It.IsAny<string>())).Returns(expected.UserPassword);
            //Act
            var result = await service.RegisterUser(fakeDto);
            //Assert
            result.Should().BeOfType<User>();
        }

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid, guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString());
        }
    }
}
