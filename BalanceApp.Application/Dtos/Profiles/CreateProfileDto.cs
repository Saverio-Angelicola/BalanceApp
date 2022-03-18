namespace BalanceApp.Application.Dtos.Profiles
{
    public record CreateProfileDto
    {
        public double Height { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Gender { get; set; }
        public string BirthDate { get; private set; }

        public CreateProfileDto(double height, string firstname, string lastname, int gender, string birthDate)
        {
            Height = height;
            Firstname = firstname;
            Lastname = lastname;
            Gender = gender;
            BirthDate = birthDate;
        }
    }
}
