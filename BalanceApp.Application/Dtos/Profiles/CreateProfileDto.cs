namespace BalanceApp.Application.Dtos.Profiles
{
    public record CreateProfileDto
    {
        public double Height { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; private set; }

        public CreateProfileDto()
        {
            Height = double.NaN;
            Firstname = string.Empty;
            Lastname = string.Empty;
            Gender = string.Empty;
            BirthDate = string.Empty;
        }

        public CreateProfileDto(double height, string firstname, string lastname, string gender, string birthDate)
        {
            Height = height;
            Firstname = firstname;
            Lastname = lastname;
            Gender = gender;
            BirthDate = birthDate;
        }
    }
}
