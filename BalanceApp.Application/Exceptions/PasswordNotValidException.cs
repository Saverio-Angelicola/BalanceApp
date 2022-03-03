namespace BalanceApp.Application.Exceptions
{
    public class PasswordNotValidException : Exception
    {
        public PasswordNotValidException() : base("Password is not correct") { }
    }
}
