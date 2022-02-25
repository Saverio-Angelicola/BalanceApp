using BalanceApp.API.Exceptions;

namespace BalanceApp.API.Dtos.Users
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public CreateUserDto(string firstName, string lastName, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
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
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}
