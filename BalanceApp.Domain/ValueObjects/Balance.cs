using BalanceApp.Domain.Exceptions;

namespace BalanceApp.Domain.ValueObjects
{
    public record Balance
    {
        public string Name { get; }
        public string MacAddress { get; }

        public Balance(string name, string macAddress)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new EmptyBalanceNameException();
            }
            Name = name;
            MacAddress = macAddress;
        }
    }
}
