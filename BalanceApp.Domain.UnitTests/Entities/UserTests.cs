using BalanceApp.Domain.Entities;
using BalanceApp.Domain.Enums;
using BalanceApp.Domain.Exceptions;
using BalanceApp.Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
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
        public void UpdateRole_WithAdminRole_RoleIsAdmin()
        {
            //Arrange
            User user = CreateRandomUser();
            UserRole role = UserRole.Admin;
            //Act
            user.UpdateRole(role);
            //Assert
            user.Role.Should().Be("Admin");
        }

        [Fact]
        public void UpdateRole_WithUserRole_RoleIsUser()
        {
            //Arrange
            User user = CreateRandomUser();
            UserRole role = UserRole.User;
            //Act
            user.UpdateRole(role);
            //Assert
            user.Role.Should().Be("User");
        }

        [Fact]
        public void UpdateRole_WithDoctorRole_RoleIsDoctor()
        {
            //Arrange
            User user = CreateRandomUser();
            UserRole role = UserRole.Doctor;
            //Act
            user.UpdateRole(role);
            //Assert
            user.Role.Should().Be("Doctor");
        }

        [Fact]
        public void AddBodyData_WithNewBodyData_SaveBodyDataInList()
        {
            //Arrange
            User user = CreateRandomUser();
            BodyData expected = new(1, 1, 1, 1, 1, 1, 1, 1);
            //Act
            user.AddBodyData(expected);
            //Assert
            user.BodyDatas.FindLast(body => true).Should().BeEquivalentTo(expected, options => options.ComparingByMembers<BodyData>());
        }

        [Fact]
        public void AddBodyDatas_WithTwoItems_ListHasTwoItems()
        {
            //Arrange
            User user = CreateRandomUser();
            BodyData expected = new(1, 1, 1, 1, 1, 1, 1, 1);
            List<BodyData> BdList = new() { expected, expected };
            //Act
            user.AddBodyDatas(BdList);
            //Assert
            user.BodyDatas.Count.Should().Be(2);
        }

        [Fact]
        public void AddBalance_WithNewBalance_SaveBalance()
        {
            //Arrange
            User user = CreateRandomUser();
            Balance balance = CreateRandomBalance();
            //Act
            user.AddBalance(balance);
            //Assert
            user.Balances.Count.Should().Be(1);
        }

        [Fact]
        public void AddBalance_WithExistingBalance_ThrowsException()
        {
            //Arrange
            User user = CreateRandomUser();
            Balance balance = CreateRandomBalance();
            user.AddBalance(balance);
            //Act & Assert
            Assert.Throws<BalanceNameAlreadyExistsException>(() => user.AddBalance(balance));

        }

        [Fact]
        public void AddBalances_WithOneItems_ListHasOneItems()
        {
            //Arrange
            User user = CreateRandomUser();
            List<Balance> list = new() { CreateRandomBalance() };
            //Act
            user.AddBalances(list);
            //Assert
            user.Balances.Count.Should().Be(1);
        }

        [Fact]
        public void DeleteBalance_WithOneItemAndExistingBalance_ListHasZeroItem()
        {
            //Arrange
            User user = CreateRandomUser();
            Balance deletedBalance = new("balance", "balance");
            user.AddBalance(deletedBalance);
            //Act
            user.DeleteBalance("balance");
            //Assert
            user.Balances.Count.Should().Be(0);
        }

        [Fact]
        public void DeleteBalance_WithInvalidBalance_ThrowsException()
        {
            //Arrange
            User user = CreateRandomUser();
            //Act & Assert
            Assert.Throws<BalanceNotFoundException>(() => user.DeleteBalance("balance"));
        }

        [Fact]
        public void GetBalance_WithExistingBalance_ReturnsBalance()
        {
            //Arrange
            User user = CreateRandomUser();
            Balance expected = new("balance", "balance");
            user.AddBalance(expected);
            //Act
            Balance result = user.GetBalance("balance");
            //Assert
            result.Should().BeEquivalentTo(expected, options => options.ComparingByMembers<Balance>());
        }

        [Fact]
        public void GetBalance_WithInvalidBalance_ThrowsException()
        {
            //Arrange
            User user = CreateRandomUser();
            //Act & Assert
            Assert.Throws<BalanceNotFoundException>(() => user.GetBalance("balance"));
        }

        internal static User CreateRandomUser()
        {
            Guid guid = Guid.NewGuid();
            return new(guid, guid.ToString(), guid.ToString(), guid.ToString(), guid.ToString());
        }

        internal static Balance CreateRandomBalance()
        {
            Guid guid = Guid.NewGuid();
            return new(guid.ToString(), guid.ToString());
        }
    }
}
