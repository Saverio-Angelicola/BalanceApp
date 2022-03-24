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
        public void UpdateProfile_WithCorrectProfile_ProfileUpdated()
        {
            //Arrange
            User user = CreateRandomUser();
            Profile fakeProfile = CreateRandomProfile(Guid.NewGuid());
            Profile updatedProfile = CreateRandomProfile(fakeProfile.Id);
            user.Profiles.Add(fakeProfile);
            //Act
            user.UpdateProfile(fakeProfile.Id, updatedProfile);
            //Assert
            user.Profiles.Find(x => x.Id == fakeProfile.Id).Should().BeEquivalentTo(updatedProfile, options => options.ComparingByMembers<Profile>());
        }

        [Fact]
        public void UpdateProfile_WithIncorrectProfile_ThrowsException()
        {
            //Arrange
            User user = CreateRandomUser();
            Profile updatedProfile = CreateRandomProfile(Guid.NewGuid());
            //Act & Assert
            Assert.Throws<ProfileNotFoundException>(() => user.UpdateProfile(Guid.NewGuid(), updatedProfile));
        }

        [Fact]
        public void GetProfile_WithCorrectUser_ReturnUser()
        {
            //Arrange
            User user = CreateRandomUser();
            Profile expected = CreateRandomProfile(Guid.NewGuid());
            user.Profiles.Add(expected);
            //Act
            Profile result = user.GetProfile(expected.Id);
            //Assert
            result.Should().BeEquivalentTo(expected, options => options.ComparingByMembers<Profile>());
        }

        [Fact]
        public void GetProfile_WithCorrectUser_ThrowException()
        {
            //Arrange
            User user = CreateRandomUser();
            //Act & Assert
            Assert.Throws<ProfileNotFoundException>(() => user.GetProfile(Guid.NewGuid()));
        }

        [Fact]
        public void AddBodyData_WithCorrectProfile_SaveBodyData()
        {
            //Arrange
            User user = CreateRandomUser();
            Profile profile = CreateRandomProfile(Guid.NewGuid());
            BodyData expected = CreateRandomBodyData();
            user.Profiles.Add(profile);
            //Act
            user.AddBodyData(profile.Id, expected);
            BodyData result = user.Profiles.First().BodyDatas.First();
            //Assert
            result.Should().BeEquivalentTo(expected, options => options.ComparingByMembers<BodyData>());
        }

        [Fact]
        public void AddBodyDatas_With3Element_Save3BodyData()
        {
            //Arrange
            User user = CreateRandomUser();
            Profile profile = CreateRandomProfile(Guid.NewGuid());
            List<BodyData> expected = new()
            {
                CreateRandomBodyData(),
                CreateRandomBodyData(),
                CreateRandomBodyData()
            };
            user.Profiles.Add(profile);
            //Act
            user.AddBodyDatas(profile.Id, expected);
            List<BodyData> result = user.Profiles.First().BodyDatas;
            //Assert
            result.Count.Should().Be(3);
        }

        internal static BodyData CreateRandomBodyData()
        {
            Random random = new Random();
            return new(random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble());
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
