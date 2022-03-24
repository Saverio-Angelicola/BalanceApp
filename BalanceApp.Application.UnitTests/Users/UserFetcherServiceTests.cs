using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.implementations.Users;
using BalanceApp.Domain.Entities;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BalanceApp.Application.UnitTests.Users
{
    public class UserFetcherServiceTests
    {
        private readonly Mock<IUserRepository> repositoryStub;
        private readonly UserFetcherService service;

        public UserFetcherServiceTests()
        {
            repositoryStub = new Mock<IUserRepository>();
            service = new(repositoryStub.Object);
        }

        [Fact]
        public async Task GetAllUser_WithUserList_ReturnsUserList()
        {
            //Arrange
            List<User> expected = new List<User>()
            {
                CreateRandomUser(),
                CreateRandomUser()
            };

            repositoryStub.Setup(repository => repository.FindAll()).ReturnsAsync(expected);
            //Assert
            var result = await service.GetAllUser();
            //Act
            result.Should().BeEquivalentTo(expected, options=>options.ComparingByMembers<User>());
        }

        [Fact]
        public async Task GetUserById_withUser_ReturnUser()
        {
            //Arrange
            User expected = CreateRandomUser();
            repositoryStub.Setup(repo => repo.FindById(It.IsAny<Guid>())).ReturnsAsync(expected);
            //Act
            var result = await service.GetUserById(It.IsAny<Guid>());
            //Assert
            result.Should().BeEquivalentTo(expected, options => options.ComparingByMembers<User>());
        }

        [Fact]
        public async Task GetUserByEmail_withUser_ReturnUser()
        {
            //Arrange
            User expected = CreateRandomUser();
            repositoryStub.Setup(repo => repo.FindByEmail(It.IsAny<string>())).ReturnsAsync(expected);
            //Act
            var result = await service.GetUserByEmail(It.IsAny<string>());
            //Assert
            result.Should().BeEquivalentTo(expected, options=>options.ComparingByMembers<User>());
        }

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid, guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString());
        }
    }
}
