namespace BalanceApp.Application.Dtos.Auth
{
    public class AuthTokenDto
    {
        public string Token { get; set; }

        public AuthTokenDto(string token)
        {
            Token = token;
        }
    }
}
