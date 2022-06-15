using BalanceApp.Domain.Exceptions;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Domain.Entities
{
    public class User : Entity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; private set; }
        public string UserPassword { get; private set; }

        public readonly List<BodyData> BodyDataList;
        public BirthDate BirthDate { get; set; }
        public string Role { get; private set; }
        public string RefreshToken { get; set; }
        public double Height { get; set; }
        public string LastUpdate { get; set; }
        public DateTime RegisterDate { get; private set; }

        public User() : base(Guid.NewGuid())
        {
            Firstname = string.Empty;
            Lastname = string.Empty;
            Email = string.Empty;
            UserPassword = string.Empty;
            BodyDataList = new();
            BirthDate = BirthDate.Create("0/0/0");
            Role = "User";
            RefreshToken = string.Empty;
            LastUpdate = string.Empty;
            RegisterDate = DateTime.UtcNow;
        }
        public User(Guid id, string firstname, string lastname, string email, string password, string birthDate, DateTime registerDate, string role = "User") : base(id)
        {
            Email = email;
            UserPassword = password;
            Firstname = firstname;
            Lastname = lastname;
            BodyDataList = new();
            RegisterDate = registerDate;
            LastUpdate = String.Empty;
            RefreshToken = String.Empty;
            BirthDate = BirthDate.Create(birthDate);
            Role = role;
            RefreshToken = "";
        }

        public void UpdatePassword(string password)
        {
            if (password.Length < 8)
            {
                throw new PasswordSizeException();
            }

            UserPassword = password;
        }

        public void RegisterRefreshToken(string token)
        {
            if(string.IsNullOrEmpty(token))
            {
                throw new Exception("token doesn't empty or null");
            }
            RefreshToken = token;
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
