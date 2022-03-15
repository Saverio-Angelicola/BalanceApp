using BalanceApp.Application.Dtos.Profiles;
using BalanceApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Services.interfaces.Profiles
{
    public interface IProfileUpdaterService
    {
        void UpdateProfile(string userEmail, Guid ProfileId, UpdateProfileDto updateProfileDto);
    }
}
