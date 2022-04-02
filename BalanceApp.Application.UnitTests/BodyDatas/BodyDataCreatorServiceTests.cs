using BalanceApp.Application.Dtos.BodyData;
using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.implementations.BodyDatas;
using BalanceApp.Application.Services.Providers;
using BalanceApp.Domain.Entities;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BalanceApp.Application.UnitTests.BodyDatas
{
    public class BodyDataCreatorServiceTests
    {
        private readonly Mock<IUserRepository> repositoryStub;
        private readonly Mock<IDateTimeProvider> dateStub;
        private readonly BodyDataCreatorService service;

        public BodyDataCreatorServiceTests()
        {
            repositoryStub = new();
            dateStub = new();
            service = new(repositoryStub.Object,dateStub.Object);
        }

        [Fact]
        public async Task AddBodyData_AddOneItem_BodyDatasHasOneItem()
        {
            //Arrange
            User fakeUser = CreateRandomUser();
            BodyDataDto expected = CreateRandomBodyDataDto();
            repositoryStub.Setup(repo => repo.FindByEmail(It.IsAny<string>())).ReturnsAsync(fakeUser);
            //Act
            await service.AddBodyData(fakeUser.Email, expected);
            //Assert
            fakeUser.BodyDataList.Count.Should().Be(1);
        }

        [Fact]
        public void AddBodyData_ThrowException_ThrowsAddingBodyDataException()
        {
            //Arrange
            repositoryStub.Setup(repo => repo.FindByEmail(It.IsAny<string>())).Throws(new Exception());
            //Act & Assert
            Assert.ThrowsAsync<AddingBodyDataException>(async () => await service.AddBodyData(It.IsAny<string>(), It.IsAny<BodyDataDto>()));
        }

        internal static BodyDataDto CreateRandomBodyDataDto()
        {
            Random random = new();
            return new(random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.Next(), random.NextDouble());
        }

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid, guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString(), "1/1/2000", DateTime.UtcNow);
        }
    }
}
