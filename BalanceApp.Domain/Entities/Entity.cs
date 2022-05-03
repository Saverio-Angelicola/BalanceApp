using BalanceApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
