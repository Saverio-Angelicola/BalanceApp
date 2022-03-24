using BalanceApp.Domain.Exceptions;

namespace BalanceApp.Domain.ValueObjects
{
    public record UserId
    {
        public Guid Value { get; }

        public UserId() { }

        public UserId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyUserIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(UserId id)
            => id.Value;

        public static implicit operator UserId(Guid id)
            => new(id);
    }
}
