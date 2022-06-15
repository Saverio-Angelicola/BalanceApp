namespace BalanceApp.Infrastructure.ResponseObjects
{
    public record Nonce
    {
        public string nonce { get; set; }

        public Nonce()
        {
            nonce = string.Empty;
        }
    }
}
