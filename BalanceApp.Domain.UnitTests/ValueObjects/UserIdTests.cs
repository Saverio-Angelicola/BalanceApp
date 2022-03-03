using BalanceApp.Domain.Exceptions;
using BalanceApp.Domain.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace BalanceApp.Domain.UnitTests.ValueObjects
{
    public class UserIdTests
    {
        [Fact]
        public void UserId_WithCorrectGuid_ValueNotNull()
        {
            //Arrange
            Guid expected = Guid.NewGuid();
            //Act
            UserId userId = new UserId(expected);
            //Assert
            userId.Value.Should().Be(expected);

        }

        [Fact]
        public void UserId_WithEmptyGuid_ThrowsException()
        {
            Assert.Throws<EmptyUserIdException>(() => new UserId(Guid.Empty));
        }
    }
}
