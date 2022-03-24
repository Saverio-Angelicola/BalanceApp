using BalanceApp.Domain.Exceptions;

namespace BalanceApp.Application.Dtos.Users
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public CreateUserDto(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            if (password.Length < 8)
            {
                throw new PasswordSizeException();
            }
            Password = password;
        }

        public CreateUserDto()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}
