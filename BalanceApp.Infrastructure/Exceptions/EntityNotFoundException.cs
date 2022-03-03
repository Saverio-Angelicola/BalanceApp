namespace BalanceApp.Infrastructure.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Guid id) : base($"Entity not found with id {id}") { }
    }
}
