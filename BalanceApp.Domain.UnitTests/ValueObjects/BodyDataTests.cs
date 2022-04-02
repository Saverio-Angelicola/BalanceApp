using BalanceApp.Domain.Exceptions;
using BalanceApp.Domain.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace BalanceApp.Domain.UnitTests.ValueObjects
{
    public class BodyDataTests
    {
        [Fact]
        public void BodyData_WithValueGreaterThanOne_WheightEqualToOne()
        {
            //Arrange & Act
            BodyData bodyData = new(1, 1, 1, 1, 1, 1, 1, 1, DateTime.UtcNow) ;
            // Assert
            bodyData.Weight.Should().Be(1);
        }

        [Fact]
        public void BodyData_WithValueLessThanOne_ThrowException()
        {
            Assert.Throws<BodyDataPositiveValueException>(() => new BodyData(-1, -1, -1, -1, -1, -1, -1, -1, DateTime.UtcNow));
        }
    }
}
