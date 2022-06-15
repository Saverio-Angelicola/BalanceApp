namespace BalanceApp.Infrastructure.ResponseObjects
{
    public record Token
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }

        public Token()
        {
            access_token = string.Empty;
            refresh_token = string.Empty;
        }
    }
}
