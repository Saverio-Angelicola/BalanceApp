using BalanceApp.Application.Dtos.BodyData;
using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.implementations.BodyDatas;
using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;
using FluentAssertions;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BalanceApp.Application.UnitTests.BodyDatas
{
    public class BodyDataCreatorServiceTests
    {
        private readonly Mock<IUserRepository> repositoryStub;
        private readonly BodyDataCreatorService service;

        public BodyDataCreatorServiceTests()
        {
            repositoryStub = new Mock<IUserRepository>();
            service = new BodyDataCreatorService(repositoryStub.Object);
        }

        [Fact]
        public async Task AddBodyData_AddOneItem_BodyDatasHasOneItem()
        {
            //Arrange
            User fakeUser = CreateRandomUser();
            Profile fakeProfile = CreateRandomProfile(Guid.NewGuid());
            BodyDataDto expected = CreateRandomBodyDataDto();
            fakeUser.AddProfile(fakeProfile);
            repositoryStub.Setup(repo=>repo.FindByEmail(It.IsAny<string>())).ReturnsAsync(fakeUser);
            //Act
            await service.AddBodyData(fakeProfile.Id,fakeUser.Email, expected);
            //Assert
            fakeUser.Profiles.First().BodyDatas.Count.Should().Be(1);
        }

        [Fact]
        public void AddBodyData_ThrowException_ThrowsAddingBodyDataException()
        {
            //Arrange
            repositoryStub.Setup(repo => repo.FindByEmail(It.IsAny<string>())).Throws(new Exception());
            //Act & Assert
            Assert.ThrowsAsync<AddingBodyDataException>(async () => await service.AddBodyData(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<BodyDataDto>()));
        }

        internal static BodyDataDto CreateRandomBodyDataDto()
        {
            Random random = new Random();
            return new(random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.Next(), random.NextDouble());
        }

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid, guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString());
        }
        internal static Profile CreateRandomProfile(Guid guid)
        {
            return new(guid, guid.ToString(), guid.ToString(), 0, "01/01/2000", 1.80);
        }
    }
}
