using BalanceApp.Domain.Exceptions;

namespace BalanceApp.Domain.ValueObjects
{
    public record BirthDate
    {
        public int Days { get; }
        public int Months { get; }
        public int Years { get; }

        public BirthDate(int days, int months, int years)
        {
            Days = days;
            Months = months;
            Years = years;
        }

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
