namespace BalanceApp.Application.Dtos.Profiles
{
    public record UpdateProfileDto
    {
        public double Height { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Gender { get; set; }

        public UpdateProfileDto(double height, string firstname, string lastname, int gender)
        {
            Height = height;
            Firstname = firstname;
            Lastname = lastname;
            Gender = gender;
        }
    }
}
