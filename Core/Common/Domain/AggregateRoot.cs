namespace Core.Common.Domain
{
    public abstract class AggregateRoot<TPrimaryKey> : AggregateRootDomainEventListenner
    {
        public TPrimaryKey Id { get; protected set; }

        protected AggregateRoot(TPrimaryKey id)
        {
            Id = id;
        }
    }
}