namespace BalanceApp.Domain.Exceptions
{
    public class BadGenderException : Exception
    {
        public BadGenderException() : base("the chosen gender is not correct. Only 'H' (male) or 'F' (female) values") { }
    }
}
