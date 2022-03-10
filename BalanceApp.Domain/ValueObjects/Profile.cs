using BalanceApp.Domain.Exceptions;

namespace BalanceApp.Domain.ValueObjects
{
    public record Profile
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public readonly List<BodyData> BodyDatas;
        public BirthDate BirthDate { get; private set; }

        public Profile(string firstname, string lastname, string gender, string birthdate)
        {
            Firstname = firstname;
            Lastname = lastname;
            BodyDatas = new();
            BirthDate = BirthDate.Create(birthdate);
            if (gender != "M" || gender != "F")
            {
                throw new BadGenderException();
            }
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

        public void AddBodyData(BodyData bodyData)
        {
            BodyDatas.Add(bodyData);
        }

        public void AddBodyDatas(List<BodyData> bodyDatas)
        {
            foreach (BodyData bodyData in bodyDatas)
            {
                AddBodyData(bodyData);
            }
        }
    }
}
