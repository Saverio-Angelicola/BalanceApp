namespace BalanceApp.Domain.Exceptions
{
    public class IncorrectBirthDateFormatException : Exception
    {
        public IncorrectBirthDateFormatException() : base("The birth of date format is incorrect. The correct format is jj/mm/yyyy") { }
    }
}
