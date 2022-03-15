using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Services.interfaces.Profiles
{
    public interface IProfileDeletionService
    {
        void DeleteProfile(string userEmail, Guid profileId);
    }
}
