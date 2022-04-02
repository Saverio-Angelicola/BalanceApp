using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Dtos.Users
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string BirthDate { get; set; }


        public CreateUserDto(string firstName, string lastName, string email, string password, string birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Password = password;
        }

        public CreateUserDto()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            BirthDate = string.Empty;
        }
    }
}
