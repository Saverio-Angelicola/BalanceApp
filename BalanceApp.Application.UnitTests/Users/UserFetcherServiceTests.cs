using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.implementations.Users;
using BalanceApp.Domain.Entities;
using Moq;
using System;

namespace BalanceApp.Application.UnitTests.Users
{
    public class UserFetcherServiceTests
    {
        private readonly Mock<IUserRepository> repositoryStub;
        private readonly UserFetcherService serviceStub;

        public UserFetcherServiceTests()
        {
            repositoryStub = new Mock<IUserRepository>();
            serviceStub = new(repositoryStub.Object);
        }

        

        

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid, guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString());
        }
    }
}
