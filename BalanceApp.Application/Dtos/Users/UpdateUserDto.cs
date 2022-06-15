namespace BalanceApp.Application.Dtos.Users
{
    public class UpdateUserDto
    {
        public string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public char? Role { get; set; }

        public UpdateUserDto(string email, string firstName, string lastName, char role='U')
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }

        public UpdateUserDto()
        {
            Email = string.Empty;
            LastName = null;
            FirstName = null;
            Role = 'U';
        }
    }
}
