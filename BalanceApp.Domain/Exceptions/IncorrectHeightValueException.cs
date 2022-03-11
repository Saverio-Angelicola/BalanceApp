namespace BalanceApp.Domain.Exceptions
{
    public class IncorrectHeightValueException : Exception
    {
        public IncorrectHeightValueException() : base("Height value must be greater than 0") { }
    }
}
