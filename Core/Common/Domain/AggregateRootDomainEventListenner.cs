using System;
using System.Collections.Generic;

namespace Core.Common.Domain
{
    public abstract class AggregateRootDomainEventListenner
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public virtual IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        public virtual void AddDomainEvent(IDomainEvent newEvent)
        {
            newEvent.EventTime = DateTime.Now;
            newEvent.EventSource = this;
            _domainEvents.Add(newEvent);
        }

        public virtual void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}