namespace BalanceApp.Domain.Exceptions
{
    public class BadGenderException : Exception
    {
        public BadGenderException(int gender) : base($"the value {gender} is not correct. Only '0' (male) or '1' (female) values") { }
    }
}
