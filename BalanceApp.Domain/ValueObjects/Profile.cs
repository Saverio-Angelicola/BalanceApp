using BalanceApp.Domain.Exceptions;

namespace BalanceApp.Domain.ValueObjects
{
    public record Profile
    {
        public Guid Id { get; private set; }
        public double Height { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }

        public readonly List<BodyData> BodyDatas;
        public BirthDate BirthDate { get; private set; }

        public Profile(Guid id, string firstname, string lastname, string gender, string birthdate, double height)
        {
            if (gender != "M" || gender != "F")
            {
                throw new BadGenderException();
            }

            if (height <= 0)
            {
                throw new IncorrectHeightValueException();
            }

            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            BodyDatas = new();
            Height = height;
            BirthDate = BirthDate.Create(birthdate);
            Gender = gender;
        }

        public Profile()
        {
            Firstname = string.Empty;
            Lastname = string.Empty;
            BodyDatas = new();
            Gender = string.Empty;
            BirthDate = BirthDate.Create("01/01/2000");

        }
    }
}
