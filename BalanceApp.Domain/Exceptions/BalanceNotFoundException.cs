namespace BalanceApp.Domain.Exceptions
{
    public class BalanceNotFoundException : Exception
    {
        public string BalanceName { get; }
        public BalanceNotFoundException(string balanceName) : base($"Balance '{balanceName}' was not found")
        {
            BalanceName = balanceName;
        }
    }
}
