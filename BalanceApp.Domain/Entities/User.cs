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

        public string LastUpdate { get; set; }
        public DateTime RegisterDate { get; private set; }

        public User() : base(Guid.NewGuid()) 
        {
            BodyDataList = new();
        }
        public User(Guid id, string firstname, string lastname, string email, string password, string birthDate,DateTime registerDate, string role = "User") : base(id)
        {
            Email = email;
            UserPassword = password;
            Firstname = firstname;
            Lastname = lastname;
            BodyDataList = new();
            RegisterDate = registerDate;
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
