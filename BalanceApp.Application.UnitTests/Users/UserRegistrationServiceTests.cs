using BalanceApp.Application.Dtos.Users;
using BalanceApp.Application.Providers;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.implementations.Users;
using BalanceApp.Application.Services.Providers;
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
        private readonly Mock<IDateTimeProvider> dateStub;
        private readonly Mock<IWithingsProvider> providerStub;
        private readonly UserRegistrationService service;

        public UserRegistrationServiceTests()
        {
            repository = new();
            hasher = new();
            dateStub = new();
            providerStub = new();
            service = new UserRegistrationService(repository.Object, hasher.Object, dateStub.Object,providerStub.Object);
        }

        [Fact]
        public async Task RegisterUser_WithUserCreate_ReturnUser()
        {
            //Arrange
            var expected = CreateRandomUser();
            var fakeDto = new CreateUserDto(expected.Firstname, expected.Lastname, expected.Email, expected.UserPassword, "1/1/2000");
            repository.Setup(repo => repo.Create(It.IsAny<User>())).ReturnsAsync(expected);
            hasher.Setup(service => service.HashPassword(It.IsAny<User>(), It.IsAny<string>())).Returns(expected.UserPassword);
            //Act
            var result = await service.RegisterUser(fakeDto);
            //Assert
            result.Should().BeEquivalentTo(expected, options => options.ComparingByMembers<User>());
        }

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid, guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString(), "1/1/2000", DateTime.UtcNow);
        }
    }
}