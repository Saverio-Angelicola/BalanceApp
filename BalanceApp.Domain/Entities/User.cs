using BalanceApp.Domain.Enums;
using BalanceApp.Domain.Exceptions;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Domain.Entities
{
    public class User
    {
        public UserId Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; private set; }
        public string UserPassword { get; private set; }
        public readonly List<BodyData> BodyDatas;
        public readonly List<Balance> Balances;
        public string Role { get; private set; }
        public DateTime RegisterDate { get; private set; }

        public User()
        {
            Id = Guid.NewGuid();
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            UserPassword = string.Empty;
            BodyDatas = new();
            Balances = new();
            Role = "User";
            RegisterDate = DateTime.UtcNow;
        }
        public User(Guid id, string firstName, string lastName, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserPassword = password;
            BodyDatas = new List<BodyData>();
            Balances = new List<Balance>();
            RegisterDate = DateTime.UtcNow;
            Role = "User";

        }

        public void UpdatePassword(string password)
        {
            if (password.Length < 8)
            {
                throw new PasswordSizeException();
            }

            UserPassword = password;
        }

        public void UpdateRole(UserRole role)
        {
            switch (role)
            {
                case UserRole.Admin:
                    Role = "Admin";
                    break;

                case UserRole.Doctor:
                    Role = "Doctor";
                    break;
                case UserRole.User:
                    break;
                default:
                    Role = "User";
                    break;
            }
        }

        public void AddBodyData(BodyData bodyData)
        {
            BodyDatas.Add(bodyData);
        }

        public void AddBodyDatas(List<BodyData> bodyDatas)
        {
            foreach (BodyData bodyData in bodyDatas)
            {
                AddBodyData(bodyData);
            }
        }

        public void AddBalance(Balance balance)
        {
            bool alreadyExists = Balances.Any(balance => balance.Name == balance.Name);
            if (alreadyExists)
            {
                throw new BalanceNameAlreadyExistsException(balance.Name);
            }

            Balances.Add(balance);
        }

        public void AddBalances(List<Balance> balances)
        {
            foreach (Balance balance in balances)
            {
                AddBalance(balance);
            }
        }

        public void DeleteBalance(string balanceName)
        {
            Balance? balance = Balances.FirstOrDefault(balance => balance.Name == balanceName);
            if (balance is null)
            {
                throw new BalanceNotFoundException(balanceName);
            }

            Balances.Remove(balance);
        }

        public Balance GetBalance(string balanceName)
        {
            Balance? balance = Balances.FirstOrDefault(balance => balance.Name == balanceName);
            if (balance is null)
            {
                throw new BalanceNotFoundException(balanceName);
            }

            return balance;
        }
    }
}
