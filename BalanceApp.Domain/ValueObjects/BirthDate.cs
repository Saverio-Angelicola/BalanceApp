namespace BalanceApp.Domain.ValueObjects
{
    public record BirthDate(int days, int months, int years)
    {
        public int Days { get; private set; }
        public int Months { get; private set; }
        public int Years { get; private set; }

        public static BirthDate Create(string birthdate)
        {
            string[] birthDateSplit = birthdate.Split("/");
            int days = Convert.ToInt32(birthDateSplit.FirstOrDefault());
            int months = Convert.ToInt32(birthDateSplit[1]);
            int years = Convert.ToInt32(birthDateSplit.LastOrDefault());
            return new(days, months, years);
        }

        public override string ToString()
        {
            return $"{Days}/{Months}/{Years}";
        }
    }
}
