 using BalanceApp.Domain.Exceptions;

namespace BalanceApp.Domain.ValueObjects
{
    public record BirthDate(int days, int months, int years)
    {
        public int Days { get; }
        public int Months { get; }
        public int Years { get; }

        public static BirthDate Create(string birthdate)
        {
            try
            {
                string[] birthDateSplit = birthdate.Split("/");
                int days = Convert.ToInt32(birthDateSplit.First());
                int months = Convert.ToInt32(birthDateSplit[1]);
                int years = Convert.ToInt32(birthDateSplit.Last());
                return new(days, months, years);
            }
            catch (Exception)
            {
                throw new IncorrectBirthDateFormatException();
            }

        }

        public override string ToString()
        {
            return $"{Days}/{Months}/{Years}";
        }
    }
}
