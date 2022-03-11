using BalanceApp.Application.Dtos.Profiles;
using BalanceApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Services.interfaces.Users
{
    public interface IUserProfileService
    {
        void AddProfile(string userEmail, CreateProfileDto profileDto);
        Task<Profile> GetProfile(string userEmail, Guid ProfileId);
        Task<List<Profile>> GetAllProfiles(string userEmail);
        void DeleteProfile(string userEmail, Guid profileId);
    }
}
