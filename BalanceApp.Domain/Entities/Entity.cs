using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Domain.Entities
{
    public abstract class Entity
    {
        public EntityId Id { get; private set; }

        public Entity(Guid id)
        {
            Id = id;
        }
    }
}
