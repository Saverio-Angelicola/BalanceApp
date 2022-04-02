using BalanceApp.Domain.Exceptions;

namespace BalanceApp.Domain.ValueObjects
{
    public record EntityId
    {
        public Guid Value { get; }

        public EntityId() { }

        public EntityId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyEntityIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(EntityId id)
            => id.Value;

        public static implicit operator EntityId(Guid id)
            => new(id);
    }
}
