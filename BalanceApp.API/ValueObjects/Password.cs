using BalanceApp.API.Exceptions;

namespace BalanceApp.API.ValueObjects
{
    public record Password
    {
        public string Value { get; }

        public Password(string password)
        {
            if(password.Length >= 8)
            {
                throw new PasswordSizeException();
            }
            Value = password;
        }

        public static implicit operator Password(string password) => new Password(password);
        public static implicit operator string(Password value) => value.Value;
    }
}
