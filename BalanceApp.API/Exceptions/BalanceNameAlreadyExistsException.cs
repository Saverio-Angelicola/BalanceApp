namespace BalanceApp.API.Exceptions
{
    public class BalanceNameAlreadyExistsException : Exception
    {
        public string BalanceName { get; }
        public BalanceNameAlreadyExistsException(string balanceName) : base($"{balanceName} already exists")
        {
            BalanceName = balanceName;
        }
    }
}
