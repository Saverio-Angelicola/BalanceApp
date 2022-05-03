namespace BalanceApp.Domain.Exceptions
{
    public class EmptyEntityIdException : Exception
    {
        public EmptyEntityIdException() : base("Entity ID cannot be empty") { }
    }
}
