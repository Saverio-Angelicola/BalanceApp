namespace BalanceApp.Application.Dtos.Auth
{
    public record WithingsTokenDto(string accessToken, string refreshToken)
    {
        public string AccessToken { get; set; } = accessToken;
        public string RefreshToken { get; set; } = refreshToken;
    }
}
