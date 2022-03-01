namespace BalanceApp.Application.Dtos.Auth
{
    public record LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginDto(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public LoginDto()
        {
            UserName = string.Empty;
            Password = string.Empty;
        }
    }
}
