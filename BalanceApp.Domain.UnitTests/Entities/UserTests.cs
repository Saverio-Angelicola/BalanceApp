using BalanceApp.Domain.Entities;
using BalanceApp.Domain.Exceptions;
using FluentAssertions;
using System;
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

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid, guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString(), "1/1/2000", DateTime.UtcNow);
        }

    }
}
