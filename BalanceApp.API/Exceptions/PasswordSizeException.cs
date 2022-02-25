namespace BalanceApp.API.Exceptions
{
    public class PasswordSizeException : Exception
    {
        public PasswordSizeException() : base("Password must be at least 8 characters") { }
    }
}
