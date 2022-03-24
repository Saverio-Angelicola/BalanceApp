namespace BalanceApp.Domain.Exceptions
{
    public class BodyDataPositiveValueException : Exception
    {
        public BodyDataPositiveValueException() : base("Values ​​must be positive.") { }
    }
}
