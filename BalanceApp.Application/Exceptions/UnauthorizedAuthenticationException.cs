namespace BalanceApp.Application.Exceptions
{
    public class UnauthorizedAuthenticationException : Exception
    {
        public UnauthorizedAuthenticationException(string username) : base($"Unauthorized Account Access {username}") { }
    }
}
