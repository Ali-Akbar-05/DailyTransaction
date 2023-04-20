using Domain.Primitives.Common.Abstractions;
using Domain.Primitives.Common.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public abstract class Aggregate : Entity, IAggregate
    {
        [NonSerialized]
        private readonly ConcurrentQueue<IDomainEvent> _uncommittedDomainEvents = new();

        public void ClearDomainEvents()
        {
            _uncommittedDomainEvents.Clear();
        }

        public IReadOnlyList<IDomainEvent> GetUncommittedDomainEvents()
        {
            return _uncommittedDomainEvents.ToImmutableList();
        }

        public bool HasUncommittedDomainEvents()
        {
            return _uncommittedDomainEvents.Any();
        }

        public void MarkUncommittedDomainEventAsCommitted()
        {
            throw new NotImplementedException();
        }
        public IReadOnlyList<IDomainEvent> DequeueUncommittedDomainEvents()
        {
            var events = _uncommittedDomainEvents.ToImmutableList();
            MarkUncommittedDomainEventAsCommitted();
            return events;
        }
    }
}
