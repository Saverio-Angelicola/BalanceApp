namespace BalanceApp.Application.Dtos.Users
{
    public class UpdateUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public UpdateUserDto(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public UpdateUserDto()
        {
            LastName = null;
            FirstName = null;
        }
    }
}
