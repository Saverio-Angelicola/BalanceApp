using BalanceApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Services.interfaces.Profiles
{
    public interface IProfileFetcherService
    {
        Task<Profile> GetProfile(string userEmail, Guid ProfileId);
        Task<List<Profile>> GetAllProfiles(string userEmail);
    }
}
