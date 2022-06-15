using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Dtos.Users
{
    public record CreateDoctorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string BirthDate { get; set; }
        public char Role { get; set; }


        public CreateDoctorDto(string firstName, string lastName, string email, string password, string birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Password = password;
            Role = 'D';
        }

        public CreateDoctorDto()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            BirthDate = string.Empty;
            Role = 'D';
        }
    }
}
