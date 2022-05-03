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
    public class UserUpdaterServiceTests
    {
        private readonly Mock<IUserRepository> repositoryStub;
        private readonly Mock<IPasswordHasher<User>> hasherStub;
        private readonly UserUpdaterService service;

        public UserUpdaterServiceTests()
        {
            repositoryStub = new();

            hasherStub = new();
            service = new(repositoryStub.Object, hasherStub.Object);
        }

        [Fact]
        public async Task UpdatePassword_WithCorrectPassword_ReturnUser()
        {
            //Arrange
            User expected = CreateRandomUser();
            repositoryStub.Setup(repo=>repo.FindByEmail(It.IsAny<string>())).ReturnsAsync(expected);
            hasherStub.Setup(hasher => hasher.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Success);
            repositoryStub.Setup(repo => repo.Update(It.IsAny<User>())).ReturnsAsync(expected);
            //Act
            var result = await service.UpdatePassword(It.IsAny<string>(), CreateRandomPasswordDto());
            //Assert
            result.Should().BeEquivalentTo(expected,options=>options.ComparingByMembers<User>());
        }

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid, guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString(), "1/1/2000", DateTime.UtcNow);
        }

        internal static UpdateUserPasswordDto CreateRandomPasswordDto()
        {
            Guid guid = Guid.NewGuid();
            return new(guid.ToString(), guid.ToString());
        }
    }
}
