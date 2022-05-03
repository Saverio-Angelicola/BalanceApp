using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Dtos.Users
{
    public class UserDto
    {
        public string Firstname { get;}
        public string Lastname { get;}
        public string Email { get;}
        public string BirthDate { get;}
        public string Role { get;}
        public string LastUpdate { get;}
        public DateTime RegisterDate { get;}

        public UserDto(User user)
        {
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Email = user.Email;
            BirthDate = user.BirthDate.ToString();
            Role = user.Role;
            LastUpdate = user.LastUpdate;
            RegisterDate = user.RegisterDate;
        }
    }
}
