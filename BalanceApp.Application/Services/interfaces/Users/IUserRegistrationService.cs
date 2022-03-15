using BalanceApp.Application.Dtos.Users;
using BalanceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Services.interfaces.Users
{
    public interface IUserRegistrationService
    {
        Task<User> RegisterUser(CreateUserDto createdUser);
    }
}
