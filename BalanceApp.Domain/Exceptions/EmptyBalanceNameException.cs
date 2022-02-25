namespace BalanceApp.Domain.Exceptions
{
    public class EmptyBalanceNameException : Exception
    {
        public EmptyBalanceNameException() : base("Balance name cannot be empty") { }
    }
}
