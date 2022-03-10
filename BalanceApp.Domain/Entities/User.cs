using BalanceApp.Domain.Exceptions;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Domain.Entities
{
    public class User
    {
        public UserId Id { get; private set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; private set; }
        public string UserPassword { get; private set; }

        public readonly List<Profile> Profiles;
        public string Role { get; private set; }
        public DateTime RegisterDate { get; private set; }

        public User()
        {
            Id = Guid.NewGuid();
            Email = string.Empty;
            Firstname = string.Empty;
            Lastname = string.Empty;
            UserPassword = string.Empty;
            Profiles = new();
            Role = "User";
            RegisterDate = DateTime.UtcNow;
        }
        public User(Guid id,string firstname, string lastname, string email, string password, string role = "User")
        {
            Id = id;
            Email = email;
            UserPassword = password;
            Firstname = firstname;
            Lastname = lastname;
            Profiles = new();
            RegisterDate = DateTime.UtcNow;
            Role = role;

        }

        public void UpdatePassword(string password)
        {
            if (password.Length < 8)
            {
                throw new PasswordSizeException();
            }

            UserPassword = password;
        }

        public void UpdateRole(char role)
        {
            Role = role switch
            {
                'A' => "Admin",
                'D' => "Doctor",
                'U' => "User",
                _ => "User",
            };
        }
    }
}
