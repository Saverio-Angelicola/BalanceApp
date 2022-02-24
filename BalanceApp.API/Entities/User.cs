﻿using BalanceApp.API.Enums;
using BalanceApp.API.Exceptions;
using BalanceApp.API.ValueObjects;

namespace BalanceApp.API.Entities
{
    public class User
    {
        public UserId Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; private set; }
        public string Password { get; set; }
        public readonly List<BodyData> BodyDatas;
        public readonly List<Balance> Balances;
        public string Role { get; private set; }
        public DateTime RegisterDate { get; private set; }

        public User() 
        {
            Id = Guid.NewGuid();
            FirstName = String.Empty;
            LastName = String.Empty;
            UserName = String.Empty;
            Password = String.Empty;
            BodyDatas = new();
            Balances = new();
            Role = "User";
            RegisterDate = DateTime.UtcNow;
        }
        public User(Guid id, string firstName, string lastName, string userName, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            BodyDatas = new List<BodyData>();
            Balances = new List<Balance>();
            RegisterDate = DateTime.UtcNow;
            Role = "User";

        }

        public void ChangeRole(UserRole role)
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
            foreach (var bodyData in bodyDatas)
            {
                AddBodyData(bodyData);
            }
        }

        public List<BodyData> GetBodyDatas()
        {
            return BodyDatas;
        }

        public void AddBalance(ValueObjects.Balance balance)
        {
            bool alreadyExists = Balances.Any(balance => balance.Name == balance.Name);
            if (alreadyExists)
            {
                throw new BalanceNameAlreadyExistsException(balance.Name);
            }

            Balances.Add(balance);
        }

        public void AddBalances(List<ValueObjects.Balance> balances)
        {
            foreach (var balance in balances)
            {
                AddBalance(balance);
            }
        }

        public void DeleteBalance(string balanceName)
        {
            var balance = Balances.FirstOrDefault(balance => balance.Name == balanceName);
            if (balance is null)
            {
                throw new BalanceNotFoundException(balanceName);
            }

            Balances.Remove(balance);
        }

        public ValueObjects.Balance GetBalance(string balanceName)
        {
            var balance = Balances.FirstOrDefault(balance => balance.Name == balanceName);
            if (balance is null)
            {
                throw new BalanceNotFoundException(balanceName);
            }

            return balance;
        }
    }
}
