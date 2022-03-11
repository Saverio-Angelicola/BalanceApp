namespace BalanceApp.Application.Dtos.Auth
{
    public record LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginDto(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public LoginDto()
        {
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}
