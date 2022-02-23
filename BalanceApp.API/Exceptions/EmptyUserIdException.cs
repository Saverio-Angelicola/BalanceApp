namespace BalanceApp.API.Exceptions
{
    public class EmptyUserIdException : Exception
    {
        public EmptyUserIdException() : base("Entity ID cannot be empty") { }
    }
}
