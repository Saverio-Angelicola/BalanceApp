using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.implementations.Users;
using BalanceApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;

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
    }
}
