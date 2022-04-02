using BalanceApp.Domain.Entities;
using BalanceApp.Domain.Exceptions;
using BalanceApp.Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BalanceApp.Domain.UnitTests.Entities
{
    public class UserTests
    {
        [Fact]
        public void UpdatePassword_WithLengthGreaterThanEight_PasswordSave()
        {
            //Arrange
            User user = CreateRandomUser();
            string expected = "password";
            //Act
            user.UpdatePassword(expected);
            //Assert
            user.UserPassword.Should().Be(expected);
        }

        [Fact]
        public void UpdatePassword_WithLengthLessThanEight_ThrowsException()
        {
            //Arrange
            User user = CreateRandomUser();
            string expected = "pass";
            //Act & Assert
            Assert.Throws<PasswordSizeException>(() => user.UpdatePassword(expected));
        }

        [Fact]
        public void AddBodyData_WithCorrectProfile_SaveBodyData()
        {
            //Arrange
            User user = CreateRandomUser();
            BodyData expected = CreateRandomBodyData();
            //Act
            user.AddBodyData(expected);
            BodyData result = user.BodyDataList.First();
            //Assert
            result.Should().BeEquivalentTo(expected, options => options.ComparingByMembers<BodyData>());
        }

        [Fact]
        public void AddBodyDatas_With3Element_Save3BodyData()
        {
            //Arrange
            User user = CreateRandomUser();
            List<BodyData> expected = new()
            {
                CreateRandomBodyData(),
                CreateRandomBodyData(),
                CreateRandomBodyData()
            };
            //Act
            user.AddBodyDatas(expected);
            List<BodyData> result = user.BodyDataList;
            //Assert
            result.Count.Should().Be(3);
        }

        internal static BodyData CreateRandomBodyData()
        {
            Random random = new();
            return new(random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), DateTime.UtcNow);
        }

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid, guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString(),"1/1/2000", DateTime.UtcNow);
        }

    }
}
